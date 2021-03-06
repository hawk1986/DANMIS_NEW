#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 09/25/2017 13:04:27
//     Runtime Version: 4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using DANMIS_NEW.Interface;
using DANMIS_NEW.Models;
using DANMIS_NEW.ViewModel;
using DANMIS_NEW.ViewModel.ListResult;
using DANMIS_NEW.ViewModel.SearchModel;
using ResourceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Extensions;

namespace DANMIS_NEW.Manager
{
    public class RoleManager : IRoleManager
    {
        readonly IFunctionRepository _functionRepository;
        readonly IRoleRepository _roleRepository;

        public RoleManager(
            IFunctionRepository functionRepository,
            IRoleRepository roleRepository)
        {
            _functionRepository = functionRepository;
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// 建立 Role
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Create(RoleViewModel entity)
        {
            var item = (Role)entity;

            using (var transaction = _roleRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    // 將功能加入
                    if (null != entity.FunctionID && entity.FunctionID.Any())
                    {
                        var waitFunctions = _functionRepository.Where(x => entity.FunctionID.Contains(x.ID)).ToList();
                        item.Function.AddRange(waitFunctions);
                    }
                    _roleRepository.Create(item);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// 根據 id 刪除 Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(List<Guid> id)
        {
            using (var transaction = _roleRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var itemSet = _roleRepository.Where(x => id.Contains(x.ID)).ToList();
                    if (itemSet.Any())
                    {
                        foreach (var item in itemSet)
                        {
                            _roleRepository.Delete(item);
                        }
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// 取得角色對應的 Function ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Guid> GetAccessFunctionByRoleID(Guid? id = null)
        {
            var result = new List<Guid>();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                var temp = _roleRepository.GetByID(id.Value);
                if (null != temp)
                {
                    result.AddRange(temp.Function.Select(x => x.ID));
                }
            }

            return result;
        }

        /// <summary>
        /// 根據 id 取得 Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleViewModel GetByID(Guid id)
        {
            var item = _roleRepository.GetByID(id);
            var result = (RoleViewModel)item;

            return result;
        }

        /// <summary>
        /// 取得模組與功能對應的 Dictionary
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<FunctionViewModel>> GetFunctionMappingToModule()
        {
            var function = _functionRepository.Where(x => x.IsEnable && x.Module.IsEnable);
            var result = function
                .OrderBy(x => x.Module.Sequence)
                .GroupBy(x => x.Module.Name)
                .ToDictionary(
                    x => x.Key,
                    y => y
                        .OrderBy(x => x.GroupName)
                        .ThenBy(x => x.Sequence)
                        .ToList()
                        .ConvertAll(e => (FunctionViewModel)e));

            return result;
        }

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public Paging<RoleListResult> Paging(RoleSearchModel searchModel)
        {
            // 預設集合
            var temp = _roleRepository.GetAll();

            if (searchModel.IsEnable.HasValue)
            {
                temp = temp.Where(x => x.IsEnable == searchModel.IsEnable.Value);
            }

            // 將 DB 資料轉換為列表頁呈現資料
            var tempResult = from x in temp
                             select new RoleListResult
                             {
                                 SequenceNo = x.SequenceNo,
                                 ID = x.ID,
                                 Name = x.Name,
                                 IsEnable = x.IsEnable,
                                 UpdateUser = x.UpdateUser,
                                 UpdateTime = x.UpdateTime,
                             };

            // 如有篩選條件，進行篩選
            if (!string.IsNullOrWhiteSpace(searchModel.Search))
            {
                var search = searchModel.Search.ToLower();
                tempResult = tempResult.Where(x =>
                    x.Name.Contains(search) ||
                    x.UpdateUser.Contains(search) ||
                    false);
            }

            // 進行分頁處理
            var result = new Paging<RoleListResult>();
            result.total = tempResult.Count();
            result.rows = tempResult
                .OrderBy(searchModel.Sort, searchModel.Order)
                .Skip(searchModel.Offset)
                .Take(searchModel.Limit)
                .ToList();

            return result;
        }

        /// <summary>
        /// 更新 Role
        /// </summary>
        /// <param name="entity"></param>
        public void Update(RoleViewModel entity)
        {
            using (var transaction = _roleRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var source = _roleRepository.GetByID(entity.ID);
                    source.Name = entity.Name ?? string.Empty;
                    source.IsEnable = entity.IsEnable;
                    source.UpdateUser = entity.UpdateUser;
                    source.UpdateTime = entity.UpdateTime;
                    source.Description = entity.Description ?? string.Empty;

                    if (null == entity.FunctionID)
                    {
                        entity.FunctionID = new List<Guid>();
                    }
                    // 取得新的 function
                    var newFunction = _functionRepository.Where(x => entity.FunctionID.Contains(x.ID));
                    source.Function.Clear();
                    source.Function.AddRange(newFunction);

                    //取得有哪些使用者擁有這個角色
                    var users = source.User.Where(x => x.IsToken).ToList();
                    //清除使用者的Token
                    foreach (var user in users)
                    {
                        user.IsToken = false;
                        user.HashToken = string.Empty;
                        user.TokenData = string.Empty;
                        //移除Token資料
                        TokenManager.RemoveUser(user.ID);
                    }

                    _roleRepository.Update(source);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
#pragma warning restore 1591
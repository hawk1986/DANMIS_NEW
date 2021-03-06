#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 11/06/2017 15:04:19
//     Runtime Version: 4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Extensions;
using DANMIS_NEW.Interface;
using DANMIS_NEW.Models;
using DANMIS_NEW.ViewModel;
using DANMIS_NEW.ViewModel.ListResult;
using DANMIS_NEW.ViewModel.SearchModel;
using ResourceLibrary;

namespace DANMIS_NEW.Manager
{
    public class DepartmentManager : IDepartmentManager
    {
        readonly IDepartmentRepository _departmentRepository;

        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// 建立 Department
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Create(DepartmentViewModel entity)
        {
            var item = (Department)entity;

            using (var transaction = _departmentRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    _departmentRepository.Create(item);
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
        /// 根據 id 刪除 Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(List<Guid> id)
        {
            using (var transaction = _departmentRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var itemSet = _departmentRepository.Where(x => id.Contains(x.ID)).ToList();
                    if (itemSet.Any())
                    {
                        foreach (var item in itemSet)
                        {
                            _departmentRepository.Delete(item);
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
        /// 根據 id 取得 Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DepartmentViewModel GetByID(Guid id)
        {
            var item = _departmentRepository.GetByID(id);
            var result = (DepartmentViewModel)item;

            return result;
        }

        /// <summary>
        /// 取得目前最大的順序序號
        /// </summary>
        /// <returns></returns>
        public byte GetSequence()
        {
            byte result = 0;
            if (_departmentRepository.Any())
            {
                result = _departmentRepository.GetAll().Max(x => x.Sequence);
            }

            return ++result;
        }

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public Paging<DepartmentListResult> Paging(DepartmentSearchModel searchModel)
        {
            // 預設集合
            var temp = _departmentRepository.GetAll();

            if (searchModel.IsEnable.HasValue)
            {
                temp = temp.Where(x => x.IsEnable == searchModel.IsEnable.Value);
            }

            // 將 DB 資料轉換為列表頁呈現資料
            var tempResult = from x in temp
                             select new DepartmentListResult
                             {
                                 SequenceNo = x.SequenceNo,
                                 ID = x.ID,
                                 Sequence = x.Sequence,
                                 Name = x.Name,
                                 DepartmentLevel = x.DepartmentLevel,
                                 IsEnable = x.IsEnable,
                                 UpdateUser = x.UpdateUser,
                                 UpdateTime = x.UpdateTime,
                                 FreeFields = x.FreeFields,
                                 DepartmentHead = x.Head.Name,
                                 DepartmentParent = x.Parent.Name,
                             };

            // 如有篩選條件，進行篩選
            if (!string.IsNullOrWhiteSpace(searchModel.Search))
            {
                var search = searchModel.Search.ToLower();
                tempResult = tempResult.Where(x =>
                    x.Name.Contains(search) ||
                    x.UpdateUser.Contains(search) ||
                    x.FreeFields.Contains(search) ||
                    x.DepartmentHead.Contains(search) ||
                    x.DepartmentParent.Contains(search) ||
                    false);
            }

            // 進行分頁處理
            var result = new Paging<DepartmentListResult>();
            result.total = tempResult.Count();
            result.rows = tempResult
                .OrderBy(searchModel.Sort, searchModel.Order)
                .Skip(searchModel.Offset)
                .Take(searchModel.Limit)
                .ToList();

            return result;
        }

        /// <summary>
        /// 更新 Department
        /// </summary>
        /// <param name="entity"></param>
        public void Update(DepartmentViewModel entity)
        {
            using (var transaction = _departmentRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var source = _departmentRepository.GetByID(entity.ID);
                    source.Sequence = entity.Sequence;
                    source.Name = entity.Name ?? string.Empty;
                    source.Abbreviate = entity.Abbreviate ?? string.Empty;
                    source.DepartmentLevel = entity.DepartmentLevel;
                    source.ContactTel = entity.ContactTel ?? string.Empty;
                    source.ContactFax = entity.ContactFax ?? string.Empty;
                    source.Address = entity.Address ?? string.Empty;
                    source.WebSiteUrl = entity.WebSiteUrl ?? string.Empty;
                    source.ImagePath = entity.ImagePath ?? string.Empty;
                    source.ImageAlt = entity.ImageAlt ?? string.Empty;
                    source.ImageWidth = entity.ImageWidth;
                    source.ImageHeight = entity.ImageHeight;
                    source.Description = entity.Description ?? string.Empty;
                    source.IsEnable = entity.IsEnable;
                    source.UpdateUser = entity.UpdateUser ?? string.Empty;
                    source.UpdateTime = entity.UpdateTime;
                    source.FreeFields = null == entity.FreeFields ? "{}" : entity.FreeFields.ToString();

                    source.HeadID = entity.HeadID;
                    source.ParentID = entity.ParentID;

                    _departmentRepository.Update(source);
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
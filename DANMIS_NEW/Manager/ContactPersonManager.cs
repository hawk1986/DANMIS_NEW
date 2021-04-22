#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 04/12/2021 15:45:32
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
    public class ContactPersonManager : IContactPersonManager
    {
        readonly IContactPersonRepository _contactPersonRepository;

        public ContactPersonManager(IContactPersonRepository contactPersonRepository)
        {
            _contactPersonRepository = contactPersonRepository;
        }

        /// <summary>
        /// 建立 ContactPerson
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Create(ContactPersonViewModel entity)
        {
            var item = (ContactPerson)entity;

            using (var transaction = _contactPersonRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    item.IsDeleted = false;
                    _contactPersonRepository.Create(item);
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
        /// 根據 id 刪除 ContactPerson
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(List<Guid> id)
        {
            using (var transaction = _contactPersonRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var itemSet = _contactPersonRepository.Where(x => id.Contains(x.ID)).ToList();
                    if (itemSet.Any())
                    {
                        foreach (var item in itemSet)
                        {
                            _contactPersonRepository.Delete(item);
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
        /// 根據 id 取得 ContactPerson
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContactPersonViewModel GetByID(Guid id)
        {
            var item = _contactPersonRepository.GetByID(id);
            var result = (ContactPersonViewModel)item;

            return result;
        }

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public Paging<ContactPersonListResult> Paging(ContactPersonSearchModel searchModel)
        {
            // 預設集合
            var temp = _contactPersonRepository.GetAll().Where(x => x.IsDeleted == false);

            // 將 DB 資料轉換為列表頁呈現資料
            var tempResult = from x in temp
                             select new ContactPersonListResult
                             {
                                 SequenceNo = x.SequenceNo,
                                 ID = x.ID,
                                 FactoryID = x.FactoryID,
                                 Name = x.Name,
                                 TEL = x.TEL,
                                 FAX = x.FAX,
                                 CellPhone = x.CellPhone,
                                 Email = x.Email,
                                 IsShow = x.IsShow,
                                 UpdateUser = x.UpdateUser,
                                 UpdateTime = x.UpdateTime,
                             };

            // 如有篩選條件，進行篩選
            if (!string.IsNullOrWhiteSpace(searchModel.Search))
            {
                var search = searchModel.Search.ToLower();
                tempResult = tempResult.Where(x =>                    
                    x.Name.Contains(search) ||
                    x.TEL.Contains(search) ||
                    x.FAX.Contains(search) ||
                    x.CellPhone.Contains(search) ||
                    x.Email.Contains(search) ||
                    x.IsShow.Contains(search) ||
                    x.UpdateUser.Contains(search) ||
                    false);
            }
            if (searchModel.FactoryID.HasValue && searchModel.FactoryID != new Guid())
                tempResult = tempResult.Where(x =>
                        x.FactoryID == searchModel.FactoryID ||                        
                        false);

            // 進行分頁處理
            var result = new Paging<ContactPersonListResult>();
            result.total = tempResult.Count();
            result.rows = tempResult
                .OrderBy(searchModel.Sort, searchModel.Order)
                .Skip(searchModel.Offset)
                .Take(searchModel.Limit)
                .ToList();

            foreach (var item in result.rows)
            {
                item.IsShow = item.IsShow == "1" ? "是" : "否";
            }

            return result;
        }

        /// <summary>
        /// 更新 ContactPerson
        /// </summary>
        /// <param name="entity"></param>
        public void Update(ContactPersonViewModel entity)
        {
            using (var transaction = _contactPersonRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var source = _contactPersonRepository.GetByID(entity.ID);
                    source.FactoryID = entity.FactoryID;
                    source.Name = entity.Name ?? string.Empty;
                    source.TEL = entity.TEL ?? string.Empty;
                    source.FAX = entity.FAX ?? string.Empty;
                    source.CellPhone = entity.CellPhone ?? string.Empty;
                    source.Email = entity.Email ?? string.Empty;
                    source.IsShow = entity.IsShow ?? string.Empty;
                    source.IsDeleted = entity.IsDeleted;
                    source.UpdateUser = entity.UpdateUser ?? string.Empty;
                    source.UpdateTime = entity.UpdateTime;

                    _contactPersonRepository.Update(source);
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
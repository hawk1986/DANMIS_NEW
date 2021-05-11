#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 04/28/2021 16:57:26
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
using System.Web.Mvc;

namespace DANMIS_NEW.Manager
{
    public class FactoryItemsManager : IFactoryItemsManager
    {
        readonly IFactoryItemsRepository _factoryItemsRepository;
        readonly IFileAttachedRepository _fileAttachedRepository;
        readonly IItemClassRepository _itemClassRepository;
        readonly IFactoryRepository _factoryRepository;

        public FactoryItemsManager(IFactoryItemsRepository factoryItemsRepository, IFileAttachedRepository fileAttachedRepository,
                                   IItemClassRepository itemClassRepository, IFactoryRepository factoryRepository)
        {
            _factoryItemsRepository = factoryItemsRepository;
            _fileAttachedRepository = fileAttachedRepository;
            _itemClassRepository = itemClassRepository;
            _factoryRepository = factoryRepository;
        }

        /// <summary>
        /// 建立 FactoryItems
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Create(FactoryItemsViewModel entity)
        {
            var item = (FactoryItems)entity;

            using (var transaction = _factoryItemsRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    //判斷是否新增附件檔案
                    if (entity.NewAttachedFiles.Count > 0)
                    {
                        _fileAttachedRepository.Create(entity.NewAttachedFiles);
                        item.IsAttached = true;
                    }

                    _factoryItemsRepository.Create(item);

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
        /// 根據 id 刪除 FactoryItems
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(List<Guid> id)
        {
            using (var transaction = _factoryItemsRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var itemSet = _factoryItemsRepository.Where(x => id.Contains(x.ID)).ToList();
                    if (itemSet.Any())
                    {
                        foreach (var item in itemSet)
                        {
                            _factoryItemsRepository.Delete(item);
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
        /// 根據 id 取得 FactoryItems
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FactoryItemsViewModel GetByID(Guid id)
        {
            var item = _factoryItemsRepository.GetByID(id);
            var result = (FactoryItemsViewModel)item;

            result.StockQty = result.ItemQty - result.ItemRequisitionQty;

            //判斷是否有附件檔案            
            if (item.IsAttached)
            {
                var AttachedFiles = _fileAttachedRepository.Where(x => x.ParentID == id).ToList();
                result.AttachedFiles = AttachedFiles;
            }

            return result;
        }

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public Paging<FactoryItemsListResult> Paging(FactoryItemsSearchModel searchModel)
        {
            var itemClass = _itemClassRepository.GetAll().ToList();
            var factory = _factoryRepository.GetAll().ToList();

            // 預設集合
            var temp = _factoryItemsRepository.GetAll();

            // 將 DB 資料轉換為列表頁呈現資料
            var tempResult = from x in temp
                             select new FactoryItemsListResult
                             {
                                 SequenceNo = x.SequenceNo,
                                 ID = x.ID,
                                 ItemName = x.ItemName,
                                 ItemSpecification = x.ItemSpecification,
                                 ItemClass = x.ItemClass,
                                 ItemUnit = x.ItemUnit,
                                 ItemPrice = x.ItemPrice,
                                 ItemQty = x.ItemQty,
                                 ItemRequisitionQty = x.ItemRequisitionQty,
                                 Factory = x.Factory,
                                 IsInventoryMgmt = x.IsInventoryMgmt,
                                 IsForStationery = x.IsForStationery,
                                 IsForColleague = x.IsForColleague,
                                 IsAttached = x.IsAttached,
                                 UpdateUser = x.UpdateUser,
                                 UpdateTime = x.UpdateTime,
                             };

            // 如有篩選條件，進行篩選
            if (!string.IsNullOrWhiteSpace(searchModel.Search))
            {
                var search = searchModel.Search.ToLower();
                tempResult = tempResult.Where(x =>
                    x.ItemName.Contains(search) ||
                    x.ItemSpecification.Contains(search) ||
                    x.ItemClass.Contains(search) ||
                    x.ItemUnit.Contains(search) ||
                    x.Factory.Contains(search) ||
                    x.UpdateUser.Contains(search) ||
                    false);
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Factory))
                tempResult = tempResult.Where(x =>
                    x.Factory == searchModel.Factory ||
                    false);

            if (!string.IsNullOrWhiteSpace(searchModel.ItemClass))
                tempResult = tempResult.Where(x =>
                    x.ItemClass == searchModel.ItemClass ||
                    false);

            // 進行分頁處理
            var result = new Paging<FactoryItemsListResult>();
            result.total = tempResult.Count();
            result.rows = tempResult
                .OrderBy(searchModel.Sort, searchModel.Order)
                .Skip(searchModel.Offset)
                .Take(searchModel.Limit)
                .ToList();

            foreach (var item in result.rows)
            {
                item.ItemClass = itemClass.FirstOrDefault(x => x.ID == new Guid(item.ItemClass))?.ClassName ?? "尚未分類";
                item.Factory = factory.FirstOrDefault(x => x.ID == new Guid(item.Factory))?.FactoryShortName ?? string.Empty;
            }

            return result;
        }

        /// <summary>
        /// 更新 FactoryItems
        /// </summary>
        /// <param name="entity"></param>
        public void Update(FactoryItemsViewModel entity)
        {
            using (var transaction = _factoryItemsRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var source = _factoryItemsRepository.GetByID(entity.ID);
                    source.ItemName = entity.ItemName ?? string.Empty;
                    source.ItemSpecification = entity.ItemSpecification ?? string.Empty;
                    source.ItemClass = entity.ItemClass ?? string.Empty;
                    source.ItemUnit = entity.ItemUnit ?? string.Empty;
                    source.ItemPrice = entity.ItemPrice;
                    source.ItemQty = entity.ItemQty;
                    source.ItemRequisitionQty = entity.ItemRequisitionQty;
                    source.Factory = entity.Factory ?? string.Empty;
                    source.IsInventoryMgmt = entity.IsInventoryMgmt;
                    source.IsForStationery = entity.IsForStationery;
                    source.IsForColleague = entity.IsForColleague;
                    source.IsAttached = entity.IsAttached;
                    source.UpdateUser = entity.UpdateUser ?? string.Empty;
                    source.UpdateTime = entity.UpdateTime;

                    #region File check
                    bool hasFile = source.IsAttached;
                    if (hasFile)
                    {
                        //取得已上傳的檔案
                        List<Guid> saveFilesID = _fileAttachedRepository.Where(x => x.ParentID == entity.ID).Select(x => x.ID).ToList();

                        //比對哪些檔案需要移除
                        if (saveFilesID.Count != entity.ReservedID.Count)
                        {
                            var removeList = saveFilesID.Except(entity.ReservedID).ToList();
                            //刪除檔案
                            _fileAttachedRepository.Delete(x => removeList.Contains(x.ID));
                            entity.DeleteFileID.AddRange(removeList);
                            hasFile = removeList.Count != saveFilesID.Count;
                        }
                    }
                    //判斷是否新增附件檔案
                    if (entity.NewAttachedFiles.Count > 0)
                    {                        
                        _fileAttachedRepository.Create(entity.NewAttachedFiles);

                        source.IsAttached = true;
                    }
                    #endregion

                    _factoryItemsRepository.Update(source);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdateQty(FactoryItemsViewModel entity)
        {
            using (var transaction = _factoryItemsRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var source = _factoryItemsRepository.GetByID(entity.ID);
                    source.ItemName = entity.ItemName ?? string.Empty;
                    source.ItemSpecification = entity.ItemSpecification ?? string.Empty;
                    source.ItemClass = entity.ItemClass ?? string.Empty;
                    source.ItemUnit = entity.ItemUnit ?? string.Empty;
                    source.ItemPrice = entity.ItemPrice;
                    source.ItemQty = entity.ItemQty;
                    source.ItemRequisitionQty = entity.ItemRequisitionQty;
                    source.Factory = entity.Factory ?? string.Empty;
                    source.IsInventoryMgmt = entity.IsInventoryMgmt;
                    source.IsForStationery = entity.IsForStationery;
                    source.IsForColleague = entity.IsForColleague;
                    source.IsAttached = entity.IsAttached;
                    source.UpdateUser = entity.UpdateUser ?? string.Empty;
                    source.UpdateTime = entity.UpdateTime;

                    _factoryItemsRepository.Update(source);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public SelectList GetSelectList(string itemClass)
        {
            // 預設集合
            var temp = _factoryItemsRepository.GetAll();

            // 將 DB 資料轉換為列表頁呈現資料
            var _tempResult = from x in temp
                              select new FactoryItemsListResult
                              {
                                  SequenceNo = x.SequenceNo,
                                  ID = x.ID,
                                  ItemName = x.ItemName,
                                  ItemSpecification = x.ItemSpecification,
                                  ItemClass = x.ItemClass,
                                  ItemUnit = x.ItemUnit,
                                  ItemPrice = x.ItemPrice,
                                  ItemQty = x.ItemQty,
                                  Factory = x.Factory,
                                  IsInventoryMgmt = x.IsInventoryMgmt,
                                  IsForStationery = x.IsForStationery,
                                  IsForColleague = x.IsForColleague,
                                  IsAttached = x.IsAttached,
                                  UpdateUser = x.UpdateUser,
                                  UpdateTime = x.UpdateTime,
                              };

            if (!string.IsNullOrEmpty(itemClass))
                _tempResult = _tempResult.Where(x =>
                    x.ItemClass == itemClass ||
                    false);

            // 進行分頁處理
            var tempResult = new Paging<FactoryItemsListResult>();
            tempResult.total = _tempResult.Count();
            tempResult.rows = _tempResult.OrderBy("ItemName", "asc").ToList();

            var list = new List<SelectListItem>();
            foreach (var item in tempResult.rows)
            {
                list.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.ItemName });
            }

            var result = new SelectList(list, "Value", "Text");

            return result;
        }
    }
}
#pragma warning restore 1591
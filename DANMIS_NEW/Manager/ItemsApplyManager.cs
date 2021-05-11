#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 05/10/2021 10:24:26
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
    public class ItemsApplyManager : IItemsApplyManager
    {
        readonly IItemsApplyRepository _itemsApplyRepository;
        readonly IFactoryItemsRepository _factoryItemsRepository;
        readonly IFloorManagerConfirmRepository _floorManagerConfirmRepository;
        public ItemsApplyManager(IItemsApplyRepository itemsApplyRepository, IFactoryItemsRepository factoryItemsRepository,
            IFloorManagerConfirmRepository floorManagerConfirmRepository)
        {
            _itemsApplyRepository = itemsApplyRepository;
            _factoryItemsRepository = factoryItemsRepository;
            _floorManagerConfirmRepository = floorManagerConfirmRepository;
        }

        /// <summary>
        /// 建立 ItemsApply
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Create(ItemsApplyViewModel entity)
        {
            var item = (ItemsApply)entity;

            using (var transaction = _itemsApplyRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    // 新增一筆紀錄到樓管確認
                    var floorManagerConfirm = new FloorManagerConfirm() {
                        ID = Guid.NewGuid(),
                        ApplyWDID = item.ApplyWDID,
                        ApplyBrand = item.ApplyBrand,
                        AgentWDID = string.Empty,
                        ApplyItemID = item.ItemID,
                        ApplyQty = item.Qty,
                        Status = "申請中",
                        CreateTime = item.CreateTime,
                        CreateUser = item.CreateUser,
                        UpdateTime = item.UpdateTime,
                        UpdateUser = item.UpdateUser
                    };

                    _floorManagerConfirmRepository.Create(floorManagerConfirm);

                    item.ConfirmID = floorManagerConfirm.ID;

                    _itemsApplyRepository.Create(item);

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
        /// 根據 id 刪除 ItemsApply
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Delete(List<Guid> id)
        {
            using (var transaction = _itemsApplyRepository.dbContext.Database.BeginTransaction())
            {
                try
                {
                    var itemSet = _itemsApplyRepository.Where(x => id.Contains(x.ID)).ToList();
                    if (itemSet.Any())
                    {
                        foreach (var item in itemSet)
                        {
                            item.Status = "取消申請";                            
                            _itemsApplyRepository.Update(item);
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
        /// 根據 id 取得 ItemsApply
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ItemsApplyViewModel GetByID(Guid id)
        {
            var item = _itemsApplyRepository.GetByID(id);
            var result = (ItemsApplyViewModel)item;

            return result;
        }

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public Paging<ItemsApplyListResult> Paging(ItemsApplySearchModel searchModel)
        {
            var factoryItems = _factoryItemsRepository.GetAll();

            // 預設集合(根據等入者取該使用者申請的物品)
            var temp = _itemsApplyRepository.GetAll().Where(x => searchModel.ApplyWDID != "99999999" ? x.ApplyWDID == searchModel.ApplyWDID : true);
            
            // 將 DB 資料轉換為列表頁呈現資料
            var tempResult = from x in temp
                             select new ItemsApplyListResult
                             {
                                 SequenceNo = x.SequenceNo,
                                 ID = x.ID,
                                 ItemID = x.ItemID,
                                 ItemName = factoryItems.FirstOrDefault(y => y.ID == x.ItemID).ItemName ?? string.Empty,
                                 ItemSpecification = factoryItems.FirstOrDefault(y => y.ID == x.ItemID).ItemSpecification ?? string.Empty,
                                 Qty = x.Qty,
                                 Memo = x.Memo,
                                 ApplyWDID = x.ApplyWDID,
                                 ApplyBrand = x.ApplyBrand,
                                 Status = x.Status,
                                 CreateUser = x.CreateUser,
                                 CreateTime = x.CreateTime,
                             };

            // 如有篩選條件，進行篩選
            if (!string.IsNullOrWhiteSpace(searchModel.Search))
            {
                var search = searchModel.Search.ToLower();
                var intsearch = search.All(char.IsDigit) ? Convert.ToInt32(searchModel.Search) : -1;
                tempResult = tempResult.Where(x =>
                    x.ItemName.Contains(search) ||
                    x.ItemSpecification.Contains(search) ||                
                    (intsearch != -1 ? x.Qty == intsearch : false ) ||
                    x.Memo.Contains(search) ||
                    false);
            }
            if(!string.IsNullOrEmpty(searchModel.ItemID))
                tempResult = tempResult.Where(x =>
                    x.ItemID == new Guid(searchModel.ItemID)||                    
                    false);

            // 進行分頁處理
            var result = new Paging<ItemsApplyListResult>();
            result.total = tempResult.Count();
            result.rows = tempResult
                .OrderBy(x => x.Status)
                .ThenByDescending(x => x.CreateTime)
                .ThenBy(searchModel.Sort, searchModel.Order)
                .Skip(searchModel.Offset)
                .Take(searchModel.Limit)
                .ToList();

            return result;
        }

        /// <summary>
        /// 更新 ItemsApply
        /// </summary>
        /// <param name="entity"></param>
        public void Update(ItemsApplyViewModel entity)
        {
            using (var transaction = _itemsApplyRepository.dbContext.Database.BeginTransaction())
            {
                try
                {

                    // 更新紀錄到樓管確認
                    var floorManagerConfirm = _floorManagerConfirmRepository.GetByID(entity.ConfirmID);

                    floorManagerConfirm.ApplyWDID = entity.ApplyWDID;
                    floorManagerConfirm.ApplyBrand = entity.ApplyBrand;
                    floorManagerConfirm.AgentWDID = string.Empty;
                    floorManagerConfirm.ApplyItemID = entity.ItemID;
                    floorManagerConfirm.ApplyQty = entity.Qty;
                    floorManagerConfirm.Status = "申請中";
                    floorManagerConfirm.UpdateTime = entity.UpdateTime;
                    floorManagerConfirm.UpdateUser = entity.UpdateUser;

                    _floorManagerConfirmRepository.Update(floorManagerConfirm);

                    var source = _itemsApplyRepository.GetByID(entity.ID);
                    source.ItemID = entity.ItemID;
                    source.Qty = entity.Qty;
                    source.ApplyWDID = entity.ApplyWDID ?? string.Empty;
                    source.ApplyBrand = entity.ApplyBrand ?? string.Empty;
                    source.Status = "申請中";
                    source.Memo = entity.Memo ?? string.Empty;
                    source.UpdateUser = entity.UpdateUser ?? string.Empty;
                    source.UpdateTime = entity.UpdateTime;

                    _itemsApplyRepository.Update(source);
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
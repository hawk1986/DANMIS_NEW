#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 04/28/2021 16:57:16
//     Runtime Version: 4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DANMIS_NEW.ViewModel;
using DANMIS_NEW.ViewModel.ListResult;
using DANMIS_NEW.ViewModel.SearchModel;

namespace DANMIS_NEW.Interface
{
    public interface IItemClassManager : IManager
    {
        /// <summary>
        /// 建立 ItemClass
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Create(ItemClassViewModel entity);

        /// <summary>
        /// 根據 id 刪除 ItemClass
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete(List<Guid> id);

        /// <summary>
        /// 根據 id 取得 ItemClass
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ItemClassViewModel GetByID(Guid id);

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        Paging<ItemClassListResult> Paging(ItemClassSearchModel searchModel);

        /// <summary>
        /// 更新 ItemClass
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(ItemClassViewModel entity);

        SelectList GetSelectList();
    }
}
#pragma warning restore 1591
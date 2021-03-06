#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 04/15/2021 18:55:02
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
    public interface IBrandManager : IManager
    {
        /// <summary>
        /// 建立 Brand
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Create(BrandViewModel entity);

        /// <summary>
        /// 根據 id 刪除 Brand
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete(List<Guid> id);

        /// <summary>
        /// 根據 id 取得 Brand
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BrandViewModel GetByID(Guid id);

        /// <summary>
        /// 分頁
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        Paging<BrandListResult> Paging(BrandSearchModel searchModel);

        /// <summary>
        /// 更新 Brand
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(BrandViewModel entity);

        SelectList GetSelectList();
    }
}
#pragma warning restore 1591
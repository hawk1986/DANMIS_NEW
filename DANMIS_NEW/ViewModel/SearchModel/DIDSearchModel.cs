#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 04/28/2021 11:04:12
//     Runtime Version: 4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using ResourceLibrary;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DANMIS_NEW.ViewModel.SearchModel
{
    public class DIDSearchModel : SearchModel
    {
        public SelectList BrandList { get; set; }
        [Display(Name = "Brand", ResourceType = typeof(Resource))]
        public string Brand { get; set; }
    }
}
#pragma warning restore 1591
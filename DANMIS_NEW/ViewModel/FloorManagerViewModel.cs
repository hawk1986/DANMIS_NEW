#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 05/05/2021 16:40:46
//	   Runtime Version: 4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using ResourceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DANMIS_NEW.ViewModel
{
    public class FloorManagerBaseModel
    {
        public FloorManagerBaseModel()
        {
            IsEnable = true;
        }

        #region == DB Fields ==

        /// <summary>
        /// SequenceNo
        /// </summary>
        public int SequenceNo { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// WDID
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "AddAdmin", ResourceType = typeof(Resource))]
        public string WDID { get; set; }

        /// <summary>
        /// Brand
        /// </summary>
        //[Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "BrandFor", ResourceType = typeof(Resource))]
        public string Brand { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "IsEnable", ResourceType = typeof(Resource))]
        public bool IsEnable { get; set; }

        /// <summary>
        /// CreateUser
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "CreateUser", ResourceType = typeof(Resource))]
        public string CreateUser { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        [Display(Name = "CreateTime", ResourceType = typeof(Resource))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// UpdateUser
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "UpdateUser", ResourceType = typeof(Resource))]
        public string UpdateUser { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>
        [Display(Name = "UpdateTime", ResourceType = typeof(Resource))]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime UpdateTime { get; set; }

        #endregion == DB Fields ==
    }

    public class FloorManagerViewModel : FloorManagerBaseModel
    {
        #region == View Fields ==
        public FloorManagerViewModel()
        {
            BrandIDs = new List<string>();
        }
        public SelectList _Users { get; set; }
        public SelectList _Brand { get; set; }
        public List<string> BrandIDs { get; set; }
        public SelectList YesNoList { get; set; }
        #endregion == View Fields ==
    }
}
#pragma warning restore 1591
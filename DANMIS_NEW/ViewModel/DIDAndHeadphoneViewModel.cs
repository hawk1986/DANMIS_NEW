#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 05/07/2021 15:39:37
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
    public class DIDAndHeadphoneBaseModel
    {
        public DIDAndHeadphoneBaseModel()
        {
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
        /// DID
        /// </summary>
        //[Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "DIDNumber", ResourceType = typeof(Resource))]
        public string DID { get; set; }

        /// <summary>
        /// HeadphoneNumber
        /// </summary>
        //[Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "HeadphoneNumber", ResourceType = typeof(Resource))]
        public string HeadphoneNumber { get; set; }

        /// <summary>
        /// Brand
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "Brand", ResourceType = typeof(Resource))]
        public string Brand { get; set; }

        /// <summary>
        /// WDID
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "WDID", ResourceType = typeof(Resource))]
        public string WDID { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(10, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "State", ResourceType = typeof(Resource))]
        public string Status { get; set; }

        /// <summary>
        /// EffectiveDate
        /// </summary>
        [Display(Name = "EffectiveDate", ResourceType = typeof(Resource))]
        public Nullable<DateTime> EffectiveDate { get; set; }

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

    public class DIDAndHeadphoneViewModel : DIDAndHeadphoneBaseModel
    {
        #region == View Fields ==
        public DIDAndHeadphoneViewModel()
        {
            User = new _User();
        }

        public SelectList DIDList { get; set; }
        public SelectList HeadphoneList { get; set; }
        public _User User { get; set; }

        [Display(Name = "EffectiveDate", ResourceType = typeof(Resource))]
        public string _EffectiveDate { get; set; }
        #endregion == View Fields ==
    }
}
#pragma warning restore 1591
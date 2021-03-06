#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Generated at 04/28/2021 11:04:26
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
    public class FactoryClassBaseModel
    {
        public FactoryClassBaseModel()
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
        /// ClassName
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Resource))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "ClassName", ResourceType = typeof(Resource))]
        public string ClassName { get; set; }

        /// <summary>
        /// Order
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(Resource))]        
        [Display(Name = "Order", ResourceType = typeof(Resource))]
        public int Order { get; set; }

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

    public class FactoryClassViewModel : FactoryClassBaseModel
    {
        #region == View Fields ==

        #endregion == View Fields ==
    }
}
#pragma warning restore 1591
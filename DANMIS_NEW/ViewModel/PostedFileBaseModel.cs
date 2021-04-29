using MultipartDataMediaFormatter.Infrastructure;
using Newtonsoft.Json;
using ResourceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using DANMIS_NEW.Models;

namespace DANMIS_NEW.ViewModel
{
    public class PostedFileBaseModel
    {
        /// <summary>
        /// 建構函數
        /// </summary>
        public PostedFileBaseModel()
        {
            AttachedFiles = new List<FileAttached>();
            NewAttachedFiles = new List<FileAttached>();            
            DeleteFileID = new List<Guid>();
            ReservedID = new List<Guid>();
            PostedCategory = new List<string>();
            PostedCaption = new List<string>();
        }

        /// <summary>
        /// 附加檔案
        /// </summary>
        [JsonIgnore]
        public List<FileAttached> AttachedFiles { get; set; }

        /// <summary>
        /// 新增的附加檔案
        /// </summary>
        [JsonIgnore]
        public List<FileAttached> NewAttachedFiles { get; set; }

        /// <summary>
        /// 刪除的檔案路徑清單
        /// </summary>
        [JsonIgnore]
        public List<Guid> DeleteFileID { get; set; }

        /// <summary>
        /// 保留的檔案編號
        /// </summary>
        [JsonIgnore]
        public List<Guid> ReservedID { get; set; }

        /// <summary>
        /// 上傳檔案的分類
        /// </summary>
        [JsonIgnore]
        public List<string> PostedCategory { get; set; }

        /// <summary>
        /// 上傳檔案的說明
        /// </summary>
        [JsonIgnore]
        public List<string> PostedCaption { get; set; }

        /// <summary>
        /// 上傳檔案清單
        /// </summary>
        [JsonIgnore]
        [Display(Name = "UploadFile", ResourceType = typeof(Resource))]
        public List<HttpPostedFileBase> PostedFiles { get; set; }

        /// <summary>
        /// 上傳檔案清單
        /// </summary>
        [JsonIgnore]
        public List<HttpFile> HttpFiles { get; set; }

    }
}
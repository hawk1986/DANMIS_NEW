//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DANMIS_NEW.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemsApply
    {
        public int SequenceNo { get; set; }
        public System.Guid ID { get; set; }
        public System.Guid ItemID { get; set; }
        public int Qty { get; set; }
        public string ApplyWDID { get; set; }
        public string ApplyBrand { get; set; }
        public string CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string UpdateUser { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public string Status { get; set; }
        public string Memo { get; set; }
    }
}

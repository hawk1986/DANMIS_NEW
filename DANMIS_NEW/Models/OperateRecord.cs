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
    
    public partial class OperateRecord
    {
        public int SequenceNo { get; set; }
        public System.Guid ID { get; set; }
        public System.Guid RecordID { get; set; }
        public string TableName { get; set; }
        public string RecordInfo { get; set; }
        public string Action { get; set; }
        public string Result { get; set; }
        public string OperateIP { get; set; }
        public string OperateUser { get; set; }
        public System.DateTime OperateTime { get; set; }
    }
}

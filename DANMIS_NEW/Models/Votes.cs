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
    
    public partial class Votes
    {
        public int SequenceNo { get; set; }
        public System.Guid ID { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Company { get; set; }
        public string VoteTo { get; set; }
        public System.DateTime VoteDate { get; set; }
        public string VoteToName { get; set; }
    }
}

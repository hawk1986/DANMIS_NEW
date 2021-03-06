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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbEntities : DbContext
    {
        public DbEntities()
            : base("name=DbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FreeFieldSetting> FreeFieldSetting { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<OperateRecord> OperateRecord { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }
        public virtual DbSet<SystemOption> SystemOption { get; set; }
        public virtual DbSet<UserChangePass> UserChangePass { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<VisualMenu> VisualMenu { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Factory> Factory { get; set; }
        public virtual DbSet<ContactPerson> ContactPerson { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Voter> Voter { get; set; }
        public virtual DbSet<Votes> Votes { get; set; }
        public virtual DbSet<FactoryClass> FactoryClass { get; set; }
        public virtual DbSet<DID> DID { get; set; }
        public virtual DbSet<FactoryItems> FactoryItems { get; set; }
        public virtual DbSet<ItemClass> ItemClass { get; set; }
        public virtual DbSet<FileAttached> FileAttached { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<FloorManager> FloorManager { get; set; }
        public virtual DbSet<Headphone> Headphone { get; set; }
        public virtual DbSet<DIDAndHeadphone> DIDAndHeadphone { get; set; }
        public virtual DbSet<FloorManagerConfirm> FloorManagerConfirm { get; set; }
        public virtual DbSet<ItemsApply> ItemsApply { get; set; }
        public virtual DbSet<BrandItems> BrandItems { get; set; }
        public virtual DbSet<BrandItemsMgmt> BrandItemsMgmt { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<Department> Department { get; set; }
    }
}

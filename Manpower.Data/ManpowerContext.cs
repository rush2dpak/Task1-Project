using Manpower.Data.Configurations;
using Manpower.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Manpower.Data
{
    public class ManpowerContext : DbContext
    {
        public ManpowerContext()
            : base("Manpower")
        {
            Database.SetInitializer<ManpowerContext>(null);
        }

        #region Entity Sets
        
        public IDbSet<Error> ErrorSet { get; set; }        
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<DataRecord> DataRecordSet { get; set; }


        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Configurations.Add(new StockConfiguration());
        }
    }
}
namespace Manpower.Data.Migrations
{

    using System;
    using Manpower.Entities;
    using System.Collections.Generic;

    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Manpower.Data.ManpowerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Manpower.Data.ManpowerContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roles = new List<Role>{
                new Role(){  Name="Admin" },
                 new Role(){  Name="Staff" }

            };
            roles.ForEach(c => context.RoleSet.AddOrUpdate(r => r.Name, c));
            context.SaveChanges();


       
        }
    }
}

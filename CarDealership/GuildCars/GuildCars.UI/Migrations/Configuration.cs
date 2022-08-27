namespace GuildCars.UI.Migrations
{
    using GuildCars.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCars.UI.Models.Identity.GuildCarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCars.UI.Models.Identity.GuildCarsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Load the user and role managers with our custom models
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            // have we loaded roles already?
            if (!roleMgr.RoleExists("admin"))
            {
                // create the admin role
                roleMgr.Create(new AppRole() { Name = "admin" });

                // create the default user
                AppUser admin1 = new AppUser()
                {
                    UserName = "robdenno@guildcars.com",
                    Email = "robdenno@guildcars.com",
                    FirstName = "Rob",
                    LastName = "Denno"
                };

                // create the user with the manager class
                userMgr.Create(admin1, "Password123");

                // add the user to the admin role
                userMgr.AddToRole(admin1.Id, "admin");
            }

            if (!roleMgr.RoleExists("sales"))
            {
                // create the sales role
                roleMgr.Create(new AppRole() { Name = "sales" });

                // create the default user
                AppUser sales1 = new AppUser()
                {
                    UserName = "billanmcmillan@guildcars.com",
                    Email = "billanmcmillan@guildcars.com",
                    FirstName = "Billan",
                    LastName = "McMillan"
                };

                AppUser sales2 = new AppUser()
                {
                    UserName = "devynsusquatch@guildcars.com",
                    Email = "devynsusquatch@guildcars.com",
                    FirstName = "Devyn",
                    LastName = "Susquatch"
                };

                AppUser sales3 = new AppUser()
                {
                    UserName = "teejayones@guildcars.com",
                    Email = "teejayones@guildcars.com",
                    FirstName = "Teejay",
                    LastName = "Ones"
                };

                // create the user with the manager class
                userMgr.Create(sales1, "Password123");
                userMgr.Create(sales2, "Password123");
                userMgr.Create(sales3, "Password123");

                // add the user to the sales role
                userMgr.AddToRole(sales1.Id, "sales");
                userMgr.AddToRole(sales2.Id, "sales");
                userMgr.AddToRole(sales3.Id, "sales");
            }

            if (!roleMgr.RoleExists("disabled"))
            {
                // create the disabled role
                roleMgr.Create(new AppRole() { Name = "disabled" });

                // create the default user
                AppUser disabled1 = new AppUser()
                {
                    UserName = "bitorhimagahd@guildcars.com",
                    Email = "bitorhimagahd@guildcars.com",
                    FirstName = "Bitor",
                    LastName = "Himagahd"
                };

                // create the user with the manager class
                userMgr.Create(disabled1, "Password123");

                // add the user to the disabled role
                userMgr.AddToRole(disabled1.Id, "disabled");
            }
        }
    }
}

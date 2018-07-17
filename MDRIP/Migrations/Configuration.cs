namespace MDRIP.Migrations
{
    using MDRIP.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MDRIP.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MDRIP.Models.ApplicationDbContext";
        }

        protected override void Seed(MDRIP.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
 //           context.Roles.AddOrUpdate(new IdentityRole() {Name="Admin"});
   //         context.SaveChanges();
 //           context.Roles.AddOrUpdate(new IdentityRole() { Name = "Health Professional" });
   //         context.Roles.AddOrUpdate(new IdentityRole() { Name = "General Public" });
     //       context.Roles.AddOrUpdate(new IdentityRole() { Name = "Researcher" });

            PasswordHasher passwordHasher = new PasswordHasher();

            context.Users.AddOrUpdate(new ApplicationUser() {
                UserName = "acuppoor@gmail.com",
                Email = "acuppoor@gmail.com",
                FirstName="Kushal S S",
                LastName="Cuppoor",
                Activated=true,
                Country="Mauritius",
                EmailConfirmed=true,
                HouseAndStreet="TestStreet",
                Region="TestRegion",
                PasswordHash=passwordHasher.HashPassword("123456aA!")
            });
            context.SaveChanges();

            //var store = new UserStore<ApplicationUser>(context);
            //var manager = new UserManager<ApplicationUser>(store);
            //manager.AddToRole(manager.FindByEmail("acuppoor@gmail.com").Id, "Admin");
                

          //  if (!context.Roles.Any(r => r.Name == "Admin"))
            //{
                // store = new RoleStore<IdentityRole>(context);
                // manager = new RoleManager<IdentityRole>(store);
           // }

            //if (!context.Users.Any(u => u.UserName == "acuppoor@gmail.com"))
           // {
                
             //   var user = new ApplicationUser
              //  {
                //    UserName = "acuppoor@gmail.com",
                  //  Email = "acuppoor@gmail.com",
                //    FirstName = "Kushal S S",
                //   LastName = "Cuppoor",
                 //   HouseAndStreet = "Some Street",
                  //  Region = "Some Suburb"
               // };

                //manager.Create(user, "123456aA!");
                //manager.AddToRole(user.Id, "Admin");
            //}
        }
    }
}

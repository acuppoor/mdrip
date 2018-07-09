using System;
using MDRIP.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MDRIP.Models
{
    public class SeedData
    {
        private MDRIPDbContext db;

        public SeedData()
        {
        }

        public SeedData(MDRIPDbContext db){
            this.db = db;
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Data.MDRIPDbContext(
                serviceProvider.GetRequiredService<Microsoft.EntityFrameworkCore.DbContextOptions<Data.MDRIPDbContext>>()))
            {
                //if (context.Users.Any())
                //{
                //    return;   // DB has been seeded
                //}
                context.SaveChanges();
            }
        }

        public void seedDb(){
            IdentityUser user = new IdentityUser() { 
                UserName = "acuppoor",
                Email = "acuppoor@gmail.com",

            };
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingWebAPI.EFCore.Model
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DatabaseContext>>()))
            {
                // Look for any movies.
                if (context.Roles.Any())
                {
                    return;   // DB has been seeded
                }

                context.Roles.AddRange(
                    new Role
                    {
                        ID=1,
                        Name="Client"
                    },

                    new Role
                    {
                        ID = 2,
                        Name = "ServiceProvider"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

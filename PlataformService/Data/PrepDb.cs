using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlataformService.Models;

namespace PlataformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }


        private static void SeedData(AppDbContext context)
        {
            if(!context.Plataforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Plataforms.AddRange(
                    new Plataform() { Name = "Dot Net", Publisher = "Ms", Cost = "Free"},
                    new Plataform() { Name = "SQL Server Express", Publisher = "Ms", Cost = "Free"},
                    new Plataform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free"}
                );

                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("--> We Already have Data!!!!! ");
            }
        }

    }
}
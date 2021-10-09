using Microsoft.EntityFrameworkCore;
using PlataformService.Models;

namespace PlataformService.Data 
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Plataform> Plataforms { get; set; }
    }
}
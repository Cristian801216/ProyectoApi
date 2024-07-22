using AplicacionAgricola.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicacionAgricola.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
        
        }

        public DbSet<Fincas> Fincas { get; set; }

        public DbSet<Grupos> Grupos { get; set; }

        public DbSet<Lotes> Lotes { get; set; }
    }
}

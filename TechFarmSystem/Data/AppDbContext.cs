using Microsoft.EntityFrameworkCore;
using TechFarmSystem.Models;

namespace TechFarmSystem.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Producao> Producao { get; set; }
        public DbSet<Funcionario> Funcionarios  { get; set; }
    }
}

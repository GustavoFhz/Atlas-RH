using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CargoModel> Cargos { get; set; }
        public DbSet<DepartamentoModel> Departamentos { get; set; }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}

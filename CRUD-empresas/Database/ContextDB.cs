using CRUD_empresas.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace CRUD_empresas.Database
{
    public class ContextDB : DbContext
    {

        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }
        

        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<Departamento> Departamentos { get; set;}

        public DbSet<FuncionarioTarefa> FuncionarioTarefas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }


    }
}

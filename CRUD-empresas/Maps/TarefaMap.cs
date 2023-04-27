using CRUD_empresas.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_empresas.Maps
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").IsRequired();

            builder.HasMany(x => x.Funcionarios)
                .WithMany(x => x.Tarefas)
                .UsingEntity<FuncionarioTarefa>(

                x => x.HasOne(p => p.Funcionarios).WithMany().HasForeignKey(p => p.FuncionarioId),
                x => x.HasOne(p=> p.Tarefa).WithMany().HasForeignKey(p=> p.TarefaId),
                x =>
                 {
                     x.ToTable("funcionarios_tarefa");

                     x.HasKey(p => new { p.FuncionarioId, p.TarefaId });

                     x.Property(p => p.FuncionarioId).HasColumnName("id_funcionario").IsRequired();
                     x.Property(p => p.TarefaId).HasColumnName("id_tarefa").IsRequired();
                 }
                ) ; ;
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CRUD_empresas.Models.Entites;

namespace CRUD_empresas.Maps
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionarios>
    {

        public void Configure(EntityTypeBuilder<Funcionarios> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();

            builder.Property(x => x.DepartamentoId).HasColumnName("id_departamento").IsRequired();
            builder.HasOne(x => x.Departamento).WithMany(x => x.Funcionarios).HasForeignKey(x=> x.DepartamentoId);

            builder.Property(x => x.EmpresaId).HasColumnName("id_empresa").IsRequired();
            builder.HasOne(x => x.Empresa).WithMany(x => x.Funcionarios).HasForeignKey(x => x.EmpresaId);


        }
    }
}

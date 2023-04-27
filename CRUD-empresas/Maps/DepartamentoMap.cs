using CRUD_empresas.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_empresas.Maps
{
    public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
           builder.HasKey(x => x.Id);
           builder.Property(x=> x.Id).HasColumnName("id").ValueGeneratedOnAdd();
           builder.Property(x=> x.Nome).HasColumnName("nome").IsRequired();
          
            
        }
    }
}

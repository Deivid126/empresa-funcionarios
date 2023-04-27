using CRUD_empresas.Models.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_empresas.Maps
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(x => x.Segmento).HasColumnName("segmento").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            builder.Property(x => x.CNPJ).HasColumnName("cnpj").IsRequired();
            builder.HasIndex(x => x.CNPJ).IsUnique();
        }
    }
}

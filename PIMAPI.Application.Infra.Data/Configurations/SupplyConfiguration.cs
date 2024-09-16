using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMAPI.Application.Abstraction.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Infra.Data.Configurations
{
    public class SupplyConfiguration : IEntityTypeConfiguration<Supply>
    {
        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder.ToTable(name : nameof(Supply));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(x => x.Nome_Empresa).IsRequired().HasMaxLength(90);
            builder.Property(x => x.CNPJ).IsRequired().HasMaxLength(90);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(90);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(90);
        }
    }
}

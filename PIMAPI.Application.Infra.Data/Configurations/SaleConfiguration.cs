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
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable(name : nameof(Sale));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(x => x.Nome_Empresa).IsRequired().HasMaxLength(90);
            builder.Property(x => x.Produto_Vendido).IsRequired().HasMaxLength(90);
            builder.Property(x => x.Quantidade_Vendida).IsRequired().HasMaxLength(90);
            builder.Property(x => x.Local_Vendido).IsRequired().HasMaxLength(90);
        }
    }
}

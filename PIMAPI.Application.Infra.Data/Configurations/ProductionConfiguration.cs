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
    public class ProductionConfiguration : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
           builder.ToTable(name: nameof(Produtos));
           builder.HasKey(x => x.Id);

           builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedNever()
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(x => x.Nome_Produto).IsRequired().HasMaxLength(90);
            builder.Property(x => x.Quantidade).IsRequired().HasMaxLength(90);
            builder.Property(x => x.Nome_Empresa).IsRequired().HasMaxLength(90);
        }
    }
}

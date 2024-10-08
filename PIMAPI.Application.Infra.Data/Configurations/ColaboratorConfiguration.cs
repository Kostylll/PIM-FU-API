﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIMAPI.Application.Abstraction.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMAPI.Application.Infra.Data.Configurations
{
    public class ColaboratorConfiguration : IEntityTypeConfiguration<Colaboradores>
    {
        public void Configure(EntityTypeBuilder<Colaboradores> builder)
        {
            builder.ToTable(name: nameof(Colaboradores));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(x => x.Nome).HasMaxLength(90).IsRequired();
            builder.Property(x => x.Data_Nascimento).HasMaxLength(90).IsRequired();
            builder.Property(x => x.Endereço).HasMaxLength(90).IsRequired();
            builder.Property(x => x.Senha).HasMaxLength(90).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(90).IsRequired();
            builder.Property(x => x.Telefone).HasMaxLength(13).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CPF).HasMaxLength(110).IsRequired();

        }
    }
}

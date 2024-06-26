﻿using CadastrarUsuario.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrarUsuario.Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Password)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired(); ;

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(13);
        }
    }
}

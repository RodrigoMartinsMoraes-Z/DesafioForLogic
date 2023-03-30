using Desafio4Logic.Domain.Clientes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio4Logic.Context.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Usuario).WithOne().HasForeignKey<Cliente>(c => c.IdUsuario);
        }
    }
}

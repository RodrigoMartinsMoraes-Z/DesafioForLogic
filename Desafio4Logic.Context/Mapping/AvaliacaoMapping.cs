using Desafio4Logic.Domain.Avaliacoes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio4Logic.Context.Mapping
{
    public class AvaliacaoMapping : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Cliente).WithMany(c => c.Avaliacoes).HasForeignKey(a => a.IdCliente);
        }
    }
}

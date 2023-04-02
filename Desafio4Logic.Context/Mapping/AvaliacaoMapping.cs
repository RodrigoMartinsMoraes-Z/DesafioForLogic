using Desafio4Logic.Domain.Avaliacoes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio4Logic.Context.Mapping
{
    public class AvaliacaoMapping : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            _ = builder.HasKey(a => a.Id);

            _ = builder.HasOne(a => a.Cliente).WithMany(c => c.Avaliacoes).HasForeignKey(a => a.IdCliente);
        }
    }
}

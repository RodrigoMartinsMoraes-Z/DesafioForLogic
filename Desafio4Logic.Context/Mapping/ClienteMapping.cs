using Desafio4Logic.Domain.Clientes;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio4Logic.Context.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            _ = builder.HasKey(c => c.Id);

            _ = builder.HasOne(c => c.Usuario).WithOne().HasForeignKey<Cliente>(c => c.IdUsuario);
        }
    }
}

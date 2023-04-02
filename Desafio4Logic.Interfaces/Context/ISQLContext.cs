using Desafio4Logic.Domain.Avaliacoes;
using Desafio4Logic.Domain.Clientes;
using Desafio4Logic.Domain.Usuarios;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace Desafio4Logic.Interfaces.Context
{
    public interface ISQLContext
    {
        DbSet<Avaliacao> Avaliacoes { get; }
        DbSet<Cliente> Clientes { get; }
        DbSet<Usuario> Usuarios { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

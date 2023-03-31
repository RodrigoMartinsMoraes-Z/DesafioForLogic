using Desafio4Logic.Domain.Usuarios;

using System.Threading.Tasks;

namespace Desafio4Logic.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task AtualizarUsuario(Usuario usuario);
        Task<Usuario> BuscarUsuarioPorId(int id);
        Task<Usuario> SalvarUsuario(Usuario usuario);
    }
}

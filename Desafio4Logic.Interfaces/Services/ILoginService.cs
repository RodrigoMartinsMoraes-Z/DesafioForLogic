using Desafio4Logic.Models;
using Desafio4Logic.Models.Usuarios;

using System.Threading.Tasks;

namespace Desafio4Logic.Interfaces.Services
{
    public interface ILoginService
    {
        Task<RespostaPadrao> RealizarLogin(UsuarioModel usuarioModel);
    }
}

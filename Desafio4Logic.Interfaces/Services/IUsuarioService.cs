using Desafio4Logic.Models;
using Desafio4Logic.Models.Usuarios;

using System.Threading.Tasks;

namespace Desafio4Logic.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<RespostaPadrao> AlterarSenha(UsuarioModel usuarioModel, string novaSenha);
        Task<RespostaPadrao> NovoUsuario(UsuarioModel usuarioModel);
    }
}

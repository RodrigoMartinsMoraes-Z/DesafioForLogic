using Desafio4Logic.Models;
using Desafio4Logic.Models.Clientes;

using System.Threading.Tasks;

namespace Desafio4Logic.Interfaces.Services
{
    public interface IClienteService
    {
        Task<RespostaPadrao> AtualizarCliente(ClienteModel clienteModel);
    }
}

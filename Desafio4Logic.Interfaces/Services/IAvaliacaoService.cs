using Desafio4Logic.Models;
using Desafio4Logic.Models.Avaliacoes;

using System.Threading.Tasks;

namespace Desafio4Logic.Interfaces.Services
{
    public interface IAvaliacaoService
    {
        Task<RespostaPadrao> BuscarAvaliacoesDoCliente(int clienteId);
        Task<RespostaPadrao> BuscarAvaliacoesDoMes(int mes, int ano);
        Task<RespostaPadrao> CadastrarAvaliação(AvaliacaoModel avaliacaoModel, int idCliente);
    }
}

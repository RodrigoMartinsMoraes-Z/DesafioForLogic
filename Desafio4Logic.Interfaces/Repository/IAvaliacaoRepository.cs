using Desafio4Logic.Domain.Avaliacoes;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio4Logic.Interfaces.Repository
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao> SalvarAvaliacao(Avaliacao avaliacao);
        Task<List<Avaliacao>> BuscarAvaliacoesPorMesAno(int mes, int ano);
        Task<List<Avaliacao>> BuscarAvaliacoesPorCliente(int idCliente);
        Task<bool> VerificaSeExisteAvaliacao(int mes, int ano, int idCliente);
    }
}

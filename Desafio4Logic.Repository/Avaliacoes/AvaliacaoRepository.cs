using Desafio4Logic.Domain.Avaliacoes;
using Desafio4Logic.Interfaces.Context;
using Desafio4Logic.Interfaces.Repository;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio4Logic.Repository.Avaliacoes
{


    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly ISQLContext _sqlContext;

        public AvaliacaoRepository(ISQLContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<Avaliacao> SalvarAvaliacao(Avaliacao avaliacao)
        {
            _sqlContext.Avaliacoes.Add(avaliacao);
            await _sqlContext.SaveChangesAsync();
            return avaliacao;
        }

        /// <summary>
        /// Busca as avaliacoes do mes e ano indicado
        /// </summary>
        /// <param name="mes"></param>
        /// <param name="ano"></param>
        /// <returns></returns>
        public async Task<List<Avaliacao>> BuscarAvaliacoesPorMesAno(int mes, int ano)
        {
            var avaliacoes = _sqlContext.Avaliacoes.Where(a => a.QuandoAvaliado.Value.Month == mes && a.QuandoAvaliado.Value.Year == ano);
            await Task.CompletedTask;
            return avaliacoes.ToList();
        }

        /// <summary>
        /// Busca as avaliacoes do cliente especificado 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public async Task<List<Avaliacao>> BuscarAvaliacoesPorCliente(int idCliente)
        {
            var avaliacoes = _sqlContext.Avaliacoes.Where(a => a.IdCliente == idCliente);
            await Task.CompletedTask;
            return avaliacoes.ToList();
        }
    }
}

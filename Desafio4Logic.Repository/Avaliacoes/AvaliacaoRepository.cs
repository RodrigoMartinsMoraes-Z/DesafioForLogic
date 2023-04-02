using Desafio4Logic.Domain.Avaliacoes;
using Desafio4Logic.Interfaces.Context;
using Desafio4Logic.Interfaces.Repository;

using Microsoft.EntityFrameworkCore;

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
            _ = _sqlContext.Avaliacoes.Add(avaliacao);
            _ = await _sqlContext.SaveChangesAsync();
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
            IQueryable<Avaliacao> avaliacoes = _sqlContext.Avaliacoes.Where(a => a.QuandoAvaliado.Value.Month == mes && a.QuandoAvaliado.Value.Year == ano);
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
            IQueryable<Avaliacao> avaliacoes = _sqlContext.Avaliacoes.Where(a => a.IdCliente == idCliente);
            await Task.CompletedTask;
            return avaliacoes.ToList();
        }

        public async Task<bool> VerificaSeExisteAvaliacao(int mes, int ano, int idCliente)
        {
            return await _sqlContext.Avaliacoes.AnyAsync(a =>
                                                                                                                                    a.IdCliente == idCliente &&
                                                                                                                                    a.QuandoAvaliado.Value.Month == mes &&
                                                                                                                                    a.QuandoAvaliado.Value.Year == ano);
        }
    }
}

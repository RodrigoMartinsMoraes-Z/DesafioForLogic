using AutoMapper;

using Desafio4Logic.Domain.Avaliacoes;
using Desafio4Logic.Interfaces.Repository;
using Desafio4Logic.Models;
using Desafio4Logic.Models.Avaliacoes;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio4Logic.Services
{
    public class AvaliacaoService
    {
        private readonly IMapper _mapper;
        private readonly IValidator<Avaliacao> _validator;
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IMapper mapper, IValidator<Avaliacao> validator, IAvaliacaoRepository avaliacaoRepository)
        {
            _mapper = mapper;
            _validator = validator;
            _avaliacaoRepository = avaliacaoRepository;
        }

        public async Task<RespostaPadrao> CadastrarAvaliação(AvaliacaoModel avaliacaoModel, int idCliente)
        {
            if (await VerificaCadastradoNoMes(idCliente))
                return new RespostaPadrao() { Status = System.Net.HttpStatusCode.Forbidden, Message = "Cliente já realizou uma avaliação neste mês." };

            var avaliacao = _mapper.Map<Avaliacao>(avaliacaoModel);
            var validarAvaliacao = _validator.Validate(avaliacao);
            if (!validarAvaliacao.IsValid)
                return new RespostaPadrao() { Status = System.Net.HttpStatusCode.BadRequest, Message = validarAvaliacao.Errors.FirstOrDefault().ErrorMessage };

            avaliacao.IdCliente = idCliente;
            await _avaliacaoRepository.SalvarAvaliacao(avaliacao);

            return new RespostaPadrao() { Status = System.Net.HttpStatusCode.OK, Message = "Avaliação cadastrada com sucesso." };
        }

        public async Task<RespostaPadrao> BuscarAvaliacoesDoMes(int mes, int ano)
        {
            var avaliacoes = await _avaliacaoRepository.BuscarAvaliacoesPorMesAno(mes, ano);
            return new RespostaPadrao() { Status = System.Net.HttpStatusCode.OK, Resposta = avaliacoes };
        }

        public async Task<RespostaPadrao> BuscarAvaliacoesDoCliente(int clienteId)
        {
            var avaliacoes = await _avaliacaoRepository.BuscarAvaliacoesPorCliente(clienteId);
            return new RespostaPadrao() { Status = System.Net.HttpStatusCode.OK, Resposta = avaliacoes };
        }

        /// <summary>
        /// verifica se o cliente ja realizou uma avaliacao neste mes
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        private async Task<bool> VerificaCadastradoNoMes(int idCliente) => await _avaliacaoRepository.VerificaSeExisteAvaliacao(DateTime.Now.Month, DateTime.Now.Year, idCliente);

    }
}

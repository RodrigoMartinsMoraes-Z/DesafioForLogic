using Desafio4Logic.Interfaces.Services;
using Desafio4Logic.Models;
using Desafio4Logic.Models.Avaliacoes;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Desafio4Logic.Api.Avaliacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IAvaliacaoService avalaicaoservice)
        {
            _avaliacaoService = avalaicaoservice;
        }

        [HttpGet]
        [Route("buscar-por-cliente")]
        public async Task<RespostaPadrao> BuscarPorCliente(int idCliente)
        {
            return await _avaliacaoService.BuscarAvaliacoesDoCliente(idCliente);
        }

        [HttpGet]
        [Route("buscar-por-mes/{mes}/{ano}")]
        public async Task<RespostaPadrao> BuscarPorCliente(int mes, int ano)
        {
            return await _avaliacaoService.BuscarAvaliacoesDoMes(mes, ano);
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<RespostaPadrao> CadastrarAvaliacao(AvaliacaoModel model)
        {
            return await _avaliacaoService.CadastrarAvaliação(model, model.Cliente.Id);
        }
    }
}

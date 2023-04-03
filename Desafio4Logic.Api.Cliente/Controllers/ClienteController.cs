using Desafio4Logic.Interfaces.Services;
using Desafio4Logic.Models;
using Desafio4Logic.Models.Clientes;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Desafio4Logic.Api.Cliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<RespostaPadrao> AtualizarCliente(ClienteModel model)
        {
            return await _clienteService.AtualizarCliente(model);
        }
    }
}

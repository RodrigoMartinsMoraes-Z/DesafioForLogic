using Desafio4Logic.Models.Clientes;
using Desafio4Logic.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio4Logic.Interfaces.Services
{
    public interface IClienteService
    {
        Task<RespostaPadrao> AtualizarCliente(ClienteModel clienteModel);
    }
}

using Desafio4Logic.Domain.Clientes;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio4Logic.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task AtualizarCliente(Cliente cliente);
        Task<Cliente> BuscarClientePorCNPJ(string cnpj);
        Task<Cliente> BuscarClientePorNome(string nome);
        Task<Cliente> SalvarCliente(Cliente cliente);
    }
}

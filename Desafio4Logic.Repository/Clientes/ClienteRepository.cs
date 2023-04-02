using Desafio4Logic.Domain.Clientes;
using Desafio4Logic.Interfaces.Context;
using Desafio4Logic.Interfaces.Repository;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace Desafio4Logic.Repository.Clientes
{


    public class ClienteRepository : IClienteRepository
    {
        private readonly ISQLContext _sqlContext;

        public ClienteRepository(ISQLContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<Cliente> BuscarClientePorNome(string nome)
        {
            return await _sqlContext.Clientes.FirstOrDefaultAsync(c => c.Nome == nome);
        }

        public async Task<Cliente> BuscarClientePorCNPJ(string cnpj)
        {
            return await _sqlContext.Clientes.FirstOrDefaultAsync(c => c.CNPJ == cnpj);
        }

        public async Task<Cliente> SalvarCliente(Cliente cliente)
        {
            _ = await _sqlContext.Clientes.AddAsync(cliente);
            _ = await _sqlContext.SaveChangesAsync();

            return cliente;
        }

        public async Task AtualizarCliente(Cliente cliente)
        {
            _ = _sqlContext.Clientes.Update(cliente);
            _ = await _sqlContext.SaveChangesAsync();
        }
    }
}

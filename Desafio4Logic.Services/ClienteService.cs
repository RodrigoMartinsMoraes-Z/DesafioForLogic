using AutoMapper;

using Desafio4Logic.Domain.Clientes;
using Desafio4Logic.Interfaces.Repository;
using Desafio4Logic.Models;
using Desafio4Logic.Models.Clientes;

using FluentValidation;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio4Logic.Services
{
    public class ClienteService
    {
        private readonly IValidator<Cliente> _validator;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IValidator<Cliente> validator, IMapper mapper, IClienteRepository clienteRepository)
        {
            _validator = validator;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<RespostaPadrao> AtualizarCliente(ClienteModel clienteModel)
        {
            try
            {
                Task<Cliente> clienteDb = _clienteRepository.BuscarClientePorCNPJ(clienteModel.CNPJ);
                Cliente cliente = _mapper.Map<Cliente>(clienteModel);
                var valid = _validator.Validate(cliente);
                if (valid != null && !valid.IsValid)
                    return new RespostaPadrao() { Status = System.Net.HttpStatusCode.BadRequest, Message = valid.Errors.First().ErrorMessage };

                cliente.Id = clienteDb.Id;
                cliente.IdUsuario = clienteDb.Id;
                await _clienteRepository.AtualizarCliente(cliente);
                return new RespostaPadrao() { Status = System.Net.HttpStatusCode.OK, Message = "Cliente atualizado com sucesso" };
            }
            catch (Exception e)
            {
                return new RespostaPadrao() { Status = System.Net.HttpStatusCode.BadRequest, Message = e.Message };
            }
        }
    }
}

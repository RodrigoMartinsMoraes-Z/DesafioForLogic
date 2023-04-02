using AutoMapper;

using Desafio4Logic.Domain.Clientes;
using Desafio4Logic.Interfaces.Repository;
using Desafio4Logic.Models;
using Desafio4Logic.Models.Clientes;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;
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
                var clienteDb = _clienteRepository.BuscarClientePorCNPJ(clienteModel.CNPJ);
                var cliente = _mapper.Map<Cliente>(clienteModel);
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

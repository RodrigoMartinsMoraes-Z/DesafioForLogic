using AutoMapper;

using Desafio4Logic.Domain.Clientes;
using Desafio4Logic.Domain.Usuarios;
using Desafio4Logic.Interfaces.Repository;
using Desafio4Logic.Interfaces.Services;
using Desafio4Logic.Models;
using Desafio4Logic.Models.Usuarios;

using FluentValidation;
using FluentValidation.Results;

using System.Linq;
using System.Threading.Tasks;

namespace Desafio4Logic.Services
{


    public class UsuarioService : IUsuarioService
    {
        private readonly IValidator<Usuario> _usuarioValidator;
        private readonly IValidator<Cliente> _clienteValidator;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IClienteRepository _clienteRepository;

        public UsuarioService(IValidator<Usuario> validator, IMapper mapper, IUsuarioRepository usuarioRepository, IValidator<Cliente> clienteValidator, IClienteRepository clienteRepository)
        {
            _usuarioValidator = validator;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _clienteValidator = clienteValidator;
            _clienteRepository = clienteRepository;
        }

        public async Task<RespostaPadrao> NovoUsuario(UsuarioModel usuarioModel)
        {
            var cnpjExiste = await _clienteRepository.BuscarClientePorCNPJ(usuarioModel.Cliente.CNPJ);

            if (cnpjExiste != null)
                return new RespostaPadrao() { Status = System.Net.HttpStatusCode.Conflict, Message = "Já existe um cliente com este CNPJ." };

            Usuario usuario = _mapper.Map<Usuario>(usuarioModel);
            Cliente cliente = _mapper.Map<Cliente>(usuarioModel.Cliente);

            ValidationResult isValid = await ValidarUsuario(usuario, cliente);

            if (isValid != null && !isValid.IsValid)
            {
                return new RespostaPadrao() { Status = System.Net.HttpStatusCode.BadRequest, Message = isValid.Errors.First().ErrorMessage };
            }

            var usuarioDb = await _usuarioRepository.SalvarUsuario(usuario);
            cliente.IdUsuario = usuarioDb.Id;
            _ = await _clienteRepository.SalvarCliente(cliente);

            return new RespostaPadrao() { Status = System.Net.HttpStatusCode.OK, Message = "Usuário cadastrado com sucesso" };
        }

        public async Task<RespostaPadrao> AlterarSenha(UsuarioModel usuarioModel, string novaSenha)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioModel);
            ValidationResult result = await _usuarioValidator.ValidateAsync(usuario);
            if (!result.IsValid)
            {
                return new RespostaPadrao() { Status = System.Net.HttpStatusCode.BadRequest, Message = result.Errors.First().ErrorMessage };
            }

            Usuario usuarioDb = await _usuarioRepository.BuscarUsuarioPorEmail(usuario.Email);
            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(usuario.Senha, usuarioDb.Senha);

            if (!senhaCorreta)
            {
                _ = new RespostaPadrao() { Status = System.Net.HttpStatusCode.Unauthorized };
            }

            usuarioDb.Senha = novaSenha;
            await _usuarioRepository.AtualizarUsuario(usuarioDb);

            return new RespostaPadrao() { Status = System.Net.HttpStatusCode.OK, Message = "Senha alterada com sucesso" };
        }

        private async Task<ValidationResult> ValidarUsuario(Usuario usuario, Cliente cliente)
        {
            ValidationResult usuarioValidation = await _usuarioValidator.ValidateAsync(usuario);
            ValidationResult clienteValidation = await _clienteValidator.ValidateAsync(cliente);

            if (usuarioValidation != null && !usuarioValidation.IsValid)
            {
                return usuarioValidation;
            }
            else if (clienteValidation != null && !clienteValidation.IsValid)
            {
                return clienteValidation;
            }

            return null;
        }

    }
}

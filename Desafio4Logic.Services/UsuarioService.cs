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

        public UsuarioService(IValidator<Usuario> validator, IMapper mapper, IUsuarioRepository usuarioRepository, IValidator<Cliente> clienteValidator)
        {
            _usuarioValidator = validator;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _clienteValidator = clienteValidator;
        }

        public async Task<RespostaPadrao> NovoUsuario(UsuarioModel usuarioModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioModel);

            var isValid = await ValidarUsuario(usuario);

            if (isValid != null || !isValid.IsValid)
                return new RespostaPadrao() { Status = System.Net.HttpStatusCode.BadRequest, Message = isValid.Errors.First().ErrorMessage };

            await _usuarioRepository.SalvarUsuario(usuario);

            return new RespostaPadrao() { Status = System.Net.HttpStatusCode.OK, Message = "Usuário cadastrado com sucesso" };
        }

        public async Task<RespostaPadrao> AlterarSenha(UsuarioModel usuarioModel, string novaSenha)
        {
            var usuario = _mapper.Map<Usuario>(usuarioModel);
            var result = await _usuarioValidator.ValidateAsync(usuario);
            if (!result.IsValid)
                return new RespostaPadrao() { Status = System.Net.HttpStatusCode.BadRequest, Message = result.Errors.First().ErrorMessage };

            var usuarioDb = await _usuarioRepository.BuscarUsuarioPorEmail(usuario.Email);
            var senhaCorreta = BCrypt.Net.BCrypt.Verify(usuario.Senha, usuarioDb.Senha);

            if (!senhaCorreta)
                new RespostaPadrao() { Status = System.Net.HttpStatusCode.Unauthorized };

            BCrypt.Net.BCrypt.ValidateAndReplacePassword(usuario.Senha, usuarioDb.Senha, novaSenha);

            return new RespostaPadrao() { Status = System.Net.HttpStatusCode.OK, Message = "Senha alterada com sucesso" };
        }

        private async Task<ValidationResult> ValidarUsuario(Usuario usuario)
        {
            var usuarioValidation = await _usuarioValidator.ValidateAsync(usuario);
            var clienteValidation = await _clienteValidator.ValidateAsync(usuario.Cliente);

            if (!usuarioValidation.IsValid)
                return usuarioValidation;
            else if (!clienteValidation.IsValid)
                return clienteValidation;

            return null;
        }

    }
}

using AutoMapper;

using Desafio4Logic.Domain.Usuarios;
using Desafio4Logic.Interfaces.Repository;
using Desafio4Logic.Interfaces.Services;
using Desafio4Logic.Models;
using Desafio4Logic.Models.Usuarios;

using FluentValidation;

using System.Linq;
using System.Threading.Tasks;

namespace Desafio4Logic.Services
{
    public class LoginService : ILoginService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IValidator<Usuario> _validator;

        public LoginService(IMapper mapper, IUsuarioRepository usuarioRepository, IValidator<Usuario> validator)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _validator = validator;
        }

        public async Task<RespostaPadrao> RealizarLogin(UsuarioModel usuarioModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioModel);
            var result = await _validator.ValidateAsync(usuario);
            if (!result.IsValid)
                return new RespostaPadrao() { Status = System.Net.HttpStatusCode.BadRequest, Message = result.Errors.First().ErrorMessage };

            var usuarioDb = await _usuarioRepository.BuscarUsuarioPorEmail(usuario.Email);
            var senhaCorreta = BCrypt.Net.BCrypt.Verify(usuario.Senha, usuarioDb.Senha);

            return senhaCorreta ? new RespostaPadrao() { Status = System.Net.HttpStatusCode.OK } : new RespostaPadrao() { Status = System.Net.HttpStatusCode.Unauthorized };
        }
    }
}

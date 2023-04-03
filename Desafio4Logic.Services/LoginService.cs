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
            Usuario usuarioDb = await _usuarioRepository.BuscarUsuarioPorEmail(usuarioModel.Email);
            bool senhaCorreta = false;

            if (usuarioDb != null)
                senhaCorreta = BCrypt.Net.BCrypt.Verify(usuarioModel.Senha, usuarioDb.Senha);

            return senhaCorreta ? new RespostaPadrao() { Status = System.Net.HttpStatusCode.OK, Message = "Login com sucesso." } : new RespostaPadrao() { Status = System.Net.HttpStatusCode.Unauthorized, Message = "Email ou senha inválida." };
        }
    }
}

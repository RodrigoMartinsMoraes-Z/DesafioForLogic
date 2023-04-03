using Desafio4Logic.Interfaces.Services;
using Desafio4Logic.Models;
using Desafio4Logic.Models.Usuarios;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Desafio4Logic.Api.Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("realizar-login")]
        public async Task<RespostaPadrao> RealizarLogin(UsuarioModel usuarioModel)
        {
            return await _loginService.RealizarLogin(usuarioModel);
        }
    }
}

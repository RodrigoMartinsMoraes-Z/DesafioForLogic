﻿using Desafio4Logic.Interfaces.Services;
using Desafio4Logic.Models;
using Desafio4Logic.Models.Usuarios;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Desafio4Logic.Api.Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("cadastro")]
        public async Task<RespostaPadrao> CadastrarUsuario(UsuarioModel model)
        {
            return await _usuarioService.NovoUsuario(model);
        }

        [HttpPut]
        [Route("atualizar-senha")]
        public async Task<RespostaPadrao> AtualizarSenha(UsuarioModel usuarioModel, string novaSenha)
        {
            return await _usuarioService.AlterarSenha(usuarioModel, novaSenha);
        }
    }
}

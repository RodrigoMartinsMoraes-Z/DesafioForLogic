using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio4Logic.Domain.Usuarios
{
    public class Usuario
    {
        private readonly string senha;

        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get => senha; set => EncriptarSenha(); }

        private string EncriptarSenha()
        {
            return BCrypt.Net.BCrypt.HashPassword(Senha);
        }
    }
}

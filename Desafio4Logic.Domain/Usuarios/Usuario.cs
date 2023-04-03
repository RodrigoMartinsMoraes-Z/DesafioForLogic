using Desafio4Logic.Domain.Clientes;

namespace Desafio4Logic.Domain.Usuarios
{
    public class Usuario
    {
        private string senha;

        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get => senha; set => senha = EncriptarSenha(value); }

        //public virtual Cliente Cliente { get; set; }

        /// <summary>
        /// encripta a senha utilizando o email como salt
        /// </summary>
        /// <returns></returns>
        private string EncriptarSenha(string value)
        {
            return BCrypt.Net.BCrypt.HashPassword(value);
        }
    }
}

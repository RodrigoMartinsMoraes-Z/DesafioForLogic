using Desafio4Logic.Models.Clientes;

namespace Desafio4Logic.Models.Usuarios
{
    public class UsuarioModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public virtual ClienteModel Cliente { get; set; }

    }
}

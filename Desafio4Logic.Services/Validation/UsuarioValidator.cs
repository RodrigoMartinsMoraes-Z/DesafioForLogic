using Desafio4Logic.Domain.Usuarios;

using FluentValidation;

namespace Desafio4Logic.Services.Validation
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            _ = RuleFor(x => x.Email).EmailAddress();
            _ = RuleFor(x => x.Senha).MinimumLength(1);
        }
    }
}

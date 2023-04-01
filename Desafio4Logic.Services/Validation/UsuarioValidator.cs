using Desafio4Logic.Domain.Usuarios;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio4Logic.Services.Validation
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Senha).MinimumLength(1);
        }
    }
}

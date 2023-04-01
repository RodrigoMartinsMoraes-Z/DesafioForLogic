using Desafio4Logic.Domain.Clientes;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio4Logic.Services.Validation
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.DataCadastro).NotEmpty();
            RuleFor(x => x.CNPJ).Length(14, 18);
            RuleFor(x => x.Nome).MinimumLength(1);
            RuleFor(x => x.NomeContato).MinimumLength(1);
        }
    }
}

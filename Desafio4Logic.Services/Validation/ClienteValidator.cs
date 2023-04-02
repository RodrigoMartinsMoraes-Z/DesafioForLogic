using Desafio4Logic.Domain.Clientes;

using FluentValidation;

namespace Desafio4Logic.Services.Validation
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            _ = RuleFor(x => x.DataCadastro).NotEmpty();
            _ = RuleFor(x => x.CNPJ).Length(14, 18);
            _ = RuleFor(x => x.Nome).MinimumLength(1);
            _ = RuleFor(x => x.NomeContato).MinimumLength(1);
        }
    }
}

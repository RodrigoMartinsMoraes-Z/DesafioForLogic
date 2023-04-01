using Desafio4Logic.Domain.Avaliacoes;

using FluentValidation;

namespace Desafio4Logic.Services.Validation
{
    public class AvaliacaoValidator : AbstractValidator<Avaliacao>
    {
        public AvaliacaoValidator()
        {
            RuleFor(x => x.Nota).GreaterThanOrEqualTo(0).LessThanOrEqualTo(10);
            RuleFor(x => x.Motivo).MinimumLength(1).MaximumLength(500);
        }
    }
}

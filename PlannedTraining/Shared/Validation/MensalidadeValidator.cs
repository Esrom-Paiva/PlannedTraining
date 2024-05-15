using FluentValidation;
using PlannedTraining.Shared.Models;

namespace PlannedTraining.Shared.Validation
{
    public class MensalidadeValidator: AbstractValidator<Mensalidade>
    {
        public MensalidadeValidator()
        {
            RuleFor(pagamento => pagamento.ValorPago).GreaterThan(decimal.Zero).WithMessage("Valor da pagamento não pode ser Zero");
        }
    }
}

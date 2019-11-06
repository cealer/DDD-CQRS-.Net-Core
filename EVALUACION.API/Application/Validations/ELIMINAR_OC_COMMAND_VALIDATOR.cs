using EVALUACION.API.Application.Commands;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace EVALUACION.API.Application.Validations
{
    public class ELIMINAR_OC_COMMAND_VALIDATOR : AbstractValidator<ELIMINAR_OC_COMMAND>
    {
        public ELIMINAR_OC_COMMAND_VALIDATOR(ILogger<EDITAR_OC_COMMAND_VALIDATOR> logger)
        {
            RuleFor(command => command.ID_HP_OC).GreaterThan(0);
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}

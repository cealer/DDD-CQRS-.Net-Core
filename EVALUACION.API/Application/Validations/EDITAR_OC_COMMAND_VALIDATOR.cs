using EVALUACION.API.Application.Commands;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVALUACION.API.Application.Validations
{
    public class EDITAR_OC_COMMAND_VALIDATOR : AbstractValidator<EDITAR_OC_COMMAND>
    {
        public EDITAR_OC_COMMAND_VALIDATOR(ILogger<EDITAR_OC_COMMAND_VALIDATOR> logger)
        {
            RuleFor(command => command.N_ID_ESTADO).GreaterThan(0);
            RuleFor(command => command.N_ID_PROVEEDOR).GreaterThan(0);
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}

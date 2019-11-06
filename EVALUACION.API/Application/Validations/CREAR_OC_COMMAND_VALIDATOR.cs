using EVALUACION.API.Application.Commands;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVALUACION.API.Application.Validations
{
    public class CREAR_OC_COMMAND_VALIDATOR : AbstractValidator<CREAR_OC_COMMAND>
    {
        public CREAR_OC_COMMAND_VALIDATOR(ILogger<CREAR_OC_COMMAND_VALIDATOR> logger)
        {
            RuleFor(command => command.N_ID_ESTADO).GreaterThan(0);
            RuleFor(command => command.N_ID_PROVEEDOR).GreaterThan(0);
            RuleFor(command => command.oC_DET_DTOs.FirstOrDefault().TURNO).MaximumLength(1);
            RuleFor(command => command.oC_DET_DTOs.FirstOrDefault().OBSERVACION).MaximumLength(100);
            RuleFor(command => command.oC_DET_DTOs.FirstOrDefault().ID_FABRICANTE).GreaterThan(0);
            RuleFor(command => command.oC_DET_DTOs.FirstOrDefault().ID_HP_OC).GreaterThan(0);
            RuleFor(command => command.oC_DET_DTOs.FirstOrDefault().ID_PRODUCTO).GreaterThan(0);
            RuleFor(command => command.oC_DET_DTOs.FirstOrDefault().FECHAESTIMADA).NotNull().NotEmpty();
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}

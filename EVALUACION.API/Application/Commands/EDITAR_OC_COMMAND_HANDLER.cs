using EVALUACION.DOMAIN.AggregatesModel.OCAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EVALUACION.API.Application.Commands
{
    public class EDITAR_OC_COMMAND_HANDLER : IRequestHandler<EDITAR_OC_COMMAND, bool>
    {
        private readonly IHP_OC_REPOSITORY _hp_ocRepository;
        private readonly ILogger<EDITAR_OC_COMMAND_HANDLER> _logger;

        public EDITAR_OC_COMMAND_HANDLER(IHP_OC_REPOSITORY _hp_ocRepository,
            ILogger<EDITAR_OC_COMMAND_HANDLER> logger)
        {
            this._hp_ocRepository = _hp_ocRepository ?? throw new ArgumentNullException(nameof(_hp_ocRepository));
            _logger = logger;
        }

        public async Task<bool> Handle(EDITAR_OC_COMMAND request,
            CancellationToken cancellationToken)
        {
            var oc = await _hp_ocRepository.GetAsync(request.ID_HP_OC);
            oc.Modificar(request.N_ID_ESTADO, request.N_ID_PROVEEDOR);
            _hp_ocRepository.Update(oc);

            var r = await _hp_ocRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            _logger.LogInformation("----- ORDEN COMPRA - ORDEN COMPRA: {@oc}", oc);

            return true;
        }
    }
}

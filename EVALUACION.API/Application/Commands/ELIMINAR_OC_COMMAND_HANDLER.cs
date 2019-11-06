using EVALUACION.DOMAIN.AggregatesModel.OCAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EVALUACION.API.Application.Commands
{
    public class ELIMINAR_OC_COMMAND_HANDLER : IRequestHandler<ELIMINAR_OC_COMMAND, bool>
    {
        private readonly IHP_OC_REPOSITORY _hp_ocRepository;
        private readonly ILogger<ELIMINAR_OC_COMMAND_HANDLER> _logger;

        public ELIMINAR_OC_COMMAND_HANDLER(IHP_OC_REPOSITORY _hp_ocRepository,
            ILogger<ELIMINAR_OC_COMMAND_HANDLER> logger)
        {
            this._hp_ocRepository = _hp_ocRepository ?? throw new ArgumentNullException(nameof(_hp_ocRepository));
            _logger = logger;
        }

        public async Task<bool> Handle(ELIMINAR_OC_COMMAND request,
            CancellationToken cancellationToken)
        {
            var oc = await _hp_ocRepository.GetAsync(request.ID_HP_OC);
            _hp_ocRepository.Delete(oc);

            var r = await _hp_ocRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            _logger.LogInformation("----- OC ELIMINADA - OC: {@oc}", oc);

            return true;
        }
    }
}
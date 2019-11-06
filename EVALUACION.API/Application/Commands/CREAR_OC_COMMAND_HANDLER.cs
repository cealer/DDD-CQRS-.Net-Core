using EVALUACION.API.Application.DTO;
using EVALUACION.DOMAIN.AggregatesModel.OCAggregate;
using EVALUACION.DOMAIN.AggregatesModel.OCAggregate._HP_OC_DET_DET;
using EVALUACION.INFRASTRUCTURE.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EVALUACION.API.Application.Commands
{
    public class CREAR_OC_COMMAND_HANDLER : IRequestHandler<CREAR_OC_COMMAND, OC_DTO>
    {
        private readonly IHP_OC_REPOSITORY _hp_ocRepository;
        private readonly IHP_OC_DET_DET_REPOSITORY hP_OC_DET_Repository;
        private readonly ILogger<CREAR_OC_COMMAND_HANDLER> _logger;

        public CREAR_OC_COMMAND_HANDLER(IHP_OC_REPOSITORY _hp_ocRepository,
            IHP_OC_DET_DET_REPOSITORY hP_OC_DET_Repository,
            ILogger<CREAR_OC_COMMAND_HANDLER> logger)
        {
            this.hP_OC_DET_Repository = hP_OC_DET_Repository;
            this._hp_ocRepository = _hp_ocRepository ?? throw new ArgumentNullException(nameof(_hp_ocRepository));
            _logger = logger;
        }

        public async Task<OC_DTO> Handle(CREAR_OC_COMMAND request,
            CancellationToken cancellationToken)
        {
            var oc = new HP_OC(request.N_ID_ESTADO, request.N_ID_PROVEEDOR);
            var det = new List<HP_OC_DET>();

            _hp_ocRepository.Add(oc);

            await _hp_ocRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            foreach (var item in request.oC_DET_DTOs)
            {
                hP_OC_DET_Repository.Add(new HP_OC_DET(oc.ID_HP_OC, item.ID_PRODUCTO, item.TURNO,
                    item.FECHAESTIMADA, item.OBSERVACION, item.ID_FABRICANTE));
            }

            await hP_OC_DET_Repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            
            _logger.LogInformation("----- ORDEN COMPRA Creado - ORDEN COMPRA: {@oc}", oc);

            return new OC_DTO
            {
                N_ID_ESTADO = oc.N_ID_ESTADO,
                N_ID_PROVEEDOR = oc.N_ID_PROVEEDOR
            };
        }

    }
}

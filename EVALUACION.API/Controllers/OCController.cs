using EVALUACION.API.Application.Commands;
using EVALUACION.API.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EVALUACION.API.Controllers
{
    [Route("api/v1/OrdenCompra")]
    [ApiController]
    public class OCController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOCQueries _iocQueries;
        private readonly ILogger<OCController> _logger;

        public OCController(
            IMediator mediator,
            IOCQueries iocQueries,
            ILogger<OCController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _iocQueries = iocQueries ?? throw new ArgumentNullException(nameof(iocQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OCViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OCViewModel>>> GetAll()
        {
            var FormatoCorreos = await _iocQueries.ListarAsync();
            return Ok(FormatoCorreos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<OCViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OCViewModel>>> GetByIdPlantillaCorreo(int id)
        {
            var FormatoCorreos = await _iocQueries.ObtenerOCAsync(id);
            return Ok(FormatoCorreos);
        }

        [HttpPost]
        public async Task<IActionResult> NuevoFormatoCorreoAsync([FromBody] CREAR_OC_COMMAND cREAR_OC_COMMAND)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "cREAR_OC_COMMAND",
                nameof(cREAR_OC_COMMAND.N_ID_PROVEEDOR),
                cREAR_OC_COMMAND.N_ID_PROVEEDOR,
                cREAR_OC_COMMAND);

            var resultado = await _mediator.Send(cREAR_OC_COMMAND);

            if (resultado != null)
            {
                return StatusCode(201, resultado);
            }

            return StatusCode(500, new { error = "Error al guardar." });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarFormatoCorreoAsync([FromRoute]int id, [FromBody] EDITAR_OC_COMMAND eDITAR_OC_COMMAND)
        {

            if (id != eDITAR_OC_COMMAND.ID_HP_OC)
            {
                return BadRequest(new { error = "Los id no coinciden" });
            }

            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "eDITAR_OC_COMMAND",
                nameof(eDITAR_OC_COMMAND.ID_HP_OC),
                eDITAR_OC_COMMAND.ID_HP_OC,
                eDITAR_OC_COMMAND);

            var resultado = await _mediator.Send(eDITAR_OC_COMMAND);

            if (resultado)
            {
                return StatusCode(204, resultado);
            }

            return StatusCode(500, new { error = "Error al actualizar." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarFormatoCorreoAsync([FromRoute] int id)
        {
            var eliminarFormatoCorreoCommand = new ELIMINAR_OC_COMMAND(id);

            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                "ELIMINAR_OC_COMMAND",
                nameof(eliminarFormatoCorreoCommand.ID_HP_OC),
                eliminarFormatoCorreoCommand.ID_HP_OC,
                eliminarFormatoCorreoCommand);

            var resultado = await _mediator.Send(eliminarFormatoCorreoCommand);

            if (resultado)
            {
                return NoContent();
            }

            return StatusCode(500, new { error = "Error al eliminar." });

        }
    }
}

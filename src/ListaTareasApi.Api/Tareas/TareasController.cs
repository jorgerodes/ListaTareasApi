using Azure;
using ListaTareasApi.Application.Tareas.FinalizarTarea;
using ListaTareasApi.Application.Tareas.ListaTareas;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ListaTareasApi.Api.Tareas
{
    [ApiController]
    [Route("/tareas")]
    public class TareasController :ControllerBase
    {
        private readonly ISender _sender;

        public TareasController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetTareasAsync(CancellationToken cancellationToken)
        {
            var query = new ListaTareasQuery();

            var response = await _sender.Send(query, cancellationToken);

            return response.IsSuccess
                ? Ok(response.Value)
                : NotFound(response.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CrearTareaAsync(
            TareaRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new CrearTareaCommand(request.Nombre,request.Orden);


            var resultado = await _sender.Send(command, cancellationToken);

            if (resultado.IsFailure)
            {
                return BadRequest(resultado.Error);
            }

            return resultado.IsSuccess
                ? Ok(resultado.Value)
                : NotFound(resultado.Error);

           


        }

        [HttpPatch("{id}/finalizar")]
        public async Task<IActionResult> FinalizarTareaASync(
            Guid id,
            CancellationToken cancellationToken)
        {
            var command = new FinalizarTareaCommand(id);

            var resultado = await _sender.Send(command, cancellationToken);

            return resultado.IsSuccess
                ? Ok(resultado.Value)
                : BadRequest(resultado.Error);
        }
    }
}

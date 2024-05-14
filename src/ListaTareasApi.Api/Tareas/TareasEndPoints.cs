using Azure;
using ListaTareasApi.Application.Tareas.FinalizarTarea;
using ListaTareasApi.Application.Tareas.ListaTareas;
using ListaTareasApi.Application.Tareas.ReordenarTareas;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.OpenApi;
using System.Runtime.CompilerServices;

namespace ListaTareasApi.Api.Tareas
{

    public static class TareasEndPoints
    {
        public static IEndpointRouteBuilder MapTareaEndpoints(this IEndpointRouteBuilder builder)
        {
            
            builder.MapGet("/tareas", GetTareasAsync);

            builder.MapPost("/tareas", CrearTareaAsync);

            builder.MapPatch("/tareas/{id}/finalizar", FinalizarTareaASync);

            builder.MapPatch("/tareas/reordenar", ReordenarTareasAsync);

            return builder;
        }

        
        public static async Task<IResult> GetTareasAsync(ISender sender,CancellationToken cancellationToken)
        {
            var query = new ListaTareasQuery();

            var response = await sender.Send(query, cancellationToken);

            return response.IsSuccess
                ? Results.Ok(response.Value)
                : Results.NotFound(response.Error);
        }

        
        public static async Task<IResult> CrearTareaAsync(
            ISender sender,
            TareaRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new CrearTareaCommand(request.Nombre,request.Orden);

            var resultado = await sender.Send(command, cancellationToken);

            if (resultado.IsFailure)
            {
                return Results.BadRequest(resultado.Error);
            }

            return resultado.IsSuccess
                ? Results.Ok(resultado.Value)
                : Results.NotFound(resultado.Error);

        }

       
        public static  async Task<IResult> FinalizarTareaASync(
            Guid id,
            ISender sender,
            CancellationToken cancellationToken)
        {
            var command = new FinalizarTareaCommand(id);

            var resultado = await sender.Send(command, cancellationToken);

            return resultado.IsSuccess
                ? Results.Ok(resultado.Value)
                : Results.BadRequest(resultado.Error);
        }


        public static async Task<IResult> ReordenarTareasAsync(
            List<OrdenaTareaRequest> request,
            ISender sender,
            CancellationToken cancellationToken)
        {

            List<Guid> guidsTareas = request.Select(x => x.Id).ToList();
            List<int> ordenes = request.Select(x => x.Orden).ToList();

            var command = new ReordenarTareasCommand(guidsTareas,ordenes);

            var resultado = await sender.Send(command, cancellationToken);

            return resultado.IsSuccess
                ? Results.Ok(resultado.Value)
                : Results.BadRequest(resultado.Error);
        }
    }
}

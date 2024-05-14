using CleanArchitecture.Domain.Alquileres;
using ListaTareasApi.Application.Abstractions.Clock;
using ListaTareasApi.Application.Abstractions.Messaging;
using ListaTareasApi.Application.Tareas.FinalizarTarea;
using ListaTareasApi.Domain.Abstractions;
using ListaTareasApi.Domain.Tareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ListaTareasApi.Application.Tareas.CrearTarea;

internal sealed class CrearTareaCommandHandler : ICommandHandler<CrearTareaCommand, TareaResponse>
{
    private readonly ITareaRepository _tareaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CrearTareaCommandHandler(
        ITareaRepository tareaRepository, 
        IUnitOfWork unitOfWork, 
        IDateTimeProvider dateTimeProvider)
    {
        _tareaRepository = tareaRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<TareaResponse>> Handle(CrearTareaCommand request, CancellationToken cancellationToken)
    {
        var nombre = new Nombre(request.Nombre);
        var tareaMismoNombre = await _tareaRepository.ExisteTareaByNameAsync(nombre);

        if (tareaMismoNombre)
        {
            return Result.Failure<TareaResponse>(TareaErrors.YaExiste);
        }

       
        var tarea = Tarea.Create(
            nombre,
            new Orden(request.Orden),
            TareaStatus.Pendiente,
            _dateTimeProvider.currentTime
        );

        await _tareaRepository.AddAsync(tarea);
        var result =  await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = new TareaResponse(tarea.Id!.Value, tarea.Nombre!.Value, tarea.Orden!.Value,tarea.Status);

        return response;

    }
}

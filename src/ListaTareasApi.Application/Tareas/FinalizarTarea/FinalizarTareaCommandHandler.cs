using ListaTareasApi.Application.Abstractions.Clock;
using ListaTareasApi.Application.Abstractions.Messaging;
using ListaTareasApi.Domain.Abstractions;
using ListaTareasApi.Domain.Tareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTareasApi.Application.Tareas.FinalizarTarea
{
    internal sealed class FinalizarTareaCommandHandler : ICommandHandler<FinalizarTareaCommand, TareaResponse>
    {
        private readonly ITareaRepository _tareaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public FinalizarTareaCommandHandler(
            ITareaRepository tareaRepository, 
            IUnitOfWork unitOfWork, 
            IDateTimeProvider dateTimeProvider)
        {
            _tareaRepository = tareaRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<TareaResponse>> Handle(FinalizarTareaCommand request, CancellationToken cancellationToken)
        {
            var tarea = await _tareaRepository.GetByIdAsync(new TareaId(request.tareaId), cancellationToken);

            if (tarea is null) {
                return Result.Failure<TareaResponse>(TareaErrors.NotFound);
            }

            var resultado = tarea.Finalizar(_dateTimeProvider.currentTime);

            if (resultado.IsFailure) return Result.Failure<TareaResponse>(TareaErrors.Hecha);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            TareaResponse response = new TareaResponse(tarea.Id!.Value, tarea.Nombre!.Value, tarea.Orden!.Value, tarea.Status);
            return Result.Success(response);
        }
    }
}

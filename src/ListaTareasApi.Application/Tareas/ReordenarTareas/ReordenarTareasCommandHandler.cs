using ListaTareasApi.Application.Abstractions.Messaging;
using ListaTareasApi.Domain.Abstractions;
using ListaTareasApi.Domain.Tareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ListaTareasApi.Application.Tareas.ReordenarTareas
{
    internal sealed class ReordenarTareasCommandHandler : ICommandHandler<ReordenarTareasCommand, IEnumerable<TareaResponse>>
    {
        private readonly ITareaRepository _tareaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ReordenarTareasCommandHandler(ITareaRepository tareaRepository, IUnitOfWork unitOfWork)
        {
            _tareaRepository = tareaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<TareaResponse>>> Handle(ReordenarTareasCommand request, CancellationToken cancellationToken)
        {
            //1. añado tareas a lista
            var listaTareas = new List<Tarea>();

            foreach (var tareaGuid in request.Tareas)
            {
                var tarea = await _tareaRepository.GetByIdAsync(new TareaId(tareaGuid));

                if(tarea is null) 
                {
                    return Result.Failure<IEnumerable<TareaResponse>>(TareaErrors.NotFound);
                }

                listaTareas.Add(tarea);
            }
            //actualizo orden de tareas
            for (int i = 0; i < listaTareas.Count; i++)
            {
                listaTareas[i].ActualizarOrden(request.Ordenes[i]);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            var tareasResponse = listaTareas.Select(t => new TareaResponse(t.Id!.Value, t.Nombre!.Value, t.Orden!.Value, t.Status));
            return Result.Success(tareasResponse);
        }
    }
}

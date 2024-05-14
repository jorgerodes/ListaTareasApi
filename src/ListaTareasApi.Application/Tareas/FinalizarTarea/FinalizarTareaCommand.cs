using ListaTareasApi.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ListaTareasApi.Application.Tareas.FinalizarTarea;

    public sealed record FinalizarTareaCommand(Guid tareaId) : ICommand<TareaResponse>;



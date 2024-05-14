using ListaTareasApi.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTareasApi.Application.Tareas.ListaTareas
{
    public sealed record ListaTareasQuery : IQuery<IEnumerable<TareaResponse>>;

}

using ListaTareasApi.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ListaTareasApi.Application.Tareas.ReordenarTareas
{
    public sealed record ReordenarTareasCommand(List<Guid> Tareas, List<int> Ordenes) : ICommand<IEnumerable<TareaResponse>>;

}

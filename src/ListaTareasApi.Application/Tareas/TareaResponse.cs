using ListaTareasApi.Domain.Tareas;

namespace ListaTareasApi.Application.Tareas;

public sealed record TareaResponse(Guid Id, string Nombre, int Orden, string StatusText)
{
    public TareaResponse(Guid id, string nombre, int orden, TareaStatus status)
        : this(id, nombre, orden, GetStatusText(status))
    {
    }

    private static string GetStatusText(TareaStatus status)
    {
        return status switch
        {
            TareaStatus.Pendiente => "Pendiente",
            TareaStatus.Hecha => "Hecha",
            _ => throw new NotImplementedException($"Texto de estado no definido para el estado {status}")
        };
    }
}


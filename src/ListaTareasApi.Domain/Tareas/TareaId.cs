
namespace ListaTareasApi.Domain.Tareas;

/// <summary>
/// Id de la tarea. Prefiero trabajar con Guid
/// </summary>
public record TareaId(Guid Value)
{
    public static TareaId FromValue(Guid Value) => new TareaId(Value);
    public static TareaId New() => FromValue(Guid.NewGuid());
}




using CleanArchitecture.Domain.Alquileres;
using ListaTareasApi.Domain.Abstractions;
using ListaTareasApi.Domain.Tareas.Events;


namespace ListaTareasApi.Domain.Tareas;

public sealed class Tarea : Entity<TareaId>
{
    private Tarea() { }

    private Tarea(
                TareaId tareaId,
                Nombre nombre,
                Orden orden,
                TareaStatus status,
                DateTime? fechaCreacionUtc)
    {
        Id = tareaId;
        Nombre = nombre;    
        Orden = orden;
        Status = status;
        FechaCreacionUtc = fechaCreacionUtc;

    }

    public Nombre? Nombre { get; private set; }
    public Orden? Orden { get; private set; }
    public TareaStatus Status { get; private set; }
    public DateTime? FechaCreacionUtc { get; private set; }
    public DateTime? FechaFinalizacion { get; private set; }

    public static Tarea Create(
                Nombre nombre,
                Orden orden,
                TareaStatus status,
                DateTime? fechaCreacionUtc)
        
    {
        var tarea = new Tarea(TareaId.New(),nombre, orden, status, fechaCreacionUtc);

        tarea.RaiseDomainEvent(new TareaCreadaDomainEvent(tarea.Id!)); //aquí puedo enviar un email, o cualquier otro evento

        return tarea;
    }

    public Result Finalizar(DateTime utcNow)
    {
        if (Status != TareaStatus.Pendiente)
        {
            return Result.Failure(TareaErrors.Hecha);
        }

        Status = TareaStatus.Hecha;
        FechaFinalizacion = utcNow;
        RaiseDomainEvent(new TareaFinalizadaDomainEvent(Id!));

        return Result.Success();
    }
}

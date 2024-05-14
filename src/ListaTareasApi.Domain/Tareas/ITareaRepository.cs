using ListaTareasApi.Domain.Abstractions;


namespace ListaTareasApi.Domain.Tareas;

public interface ITareaRepository : IRepository<Tarea,TareaId>
{
    public Task<bool> ExisteTareaByNameAsync(Nombre name);
    
}


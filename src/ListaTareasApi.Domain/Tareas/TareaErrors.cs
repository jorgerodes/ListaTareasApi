using ListaTareasApi.Domain.Abstractions;

namespace ListaTareasApi.Domain.Tareas;


public static class TareaErrors
{
    public static Error YaExiste = new Error(
        "Tarea.YaExiste",
        "Ya existe una tarea con ese nombre"
        );

    public static Error Hecha = new Error(
        "Tarea.Hecha",
        "La tarea ya está hecha"
        );

    public static Error NotFound = new Error(
        "Tarea.NotFound",
        "La tarea no se ha encontrado"
        );

}
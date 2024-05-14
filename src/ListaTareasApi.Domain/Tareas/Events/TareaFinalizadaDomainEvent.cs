using ListaTareasApi.Domain.Abstractions;


namespace ListaTareasApi.Domain.Tareas.Events;

public sealed record TareaFinalizadaDomainEvent(TareaId TareaId) : IDomainEvent;

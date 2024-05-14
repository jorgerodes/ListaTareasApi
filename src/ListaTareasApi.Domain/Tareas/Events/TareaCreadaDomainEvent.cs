using ListaTareasApi.Domain.Abstractions;
using ListaTareasApi.Domain.Tareas;

namespace ListaTareasApi.Domain.Tareas.Events;

public sealed record TareaCreadaDomainEvent(TareaId TareaId) : IDomainEvent;
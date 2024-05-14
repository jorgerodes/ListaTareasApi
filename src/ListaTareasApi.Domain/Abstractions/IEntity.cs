
using ListaTareasApi.Domain.Abstractions;

namespace ListaTareasApi.Domain.Abstractions;
public interface IEntity
    {
        IReadOnlyList<IDomainEvent> GetDomainEvents();

        void ClearDomainEvents();
    }


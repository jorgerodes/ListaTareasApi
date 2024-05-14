using ListaTareasApi.Application.Abstractions.Clock;

namespace ListaTareasApi.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime currentTime => DateTime.UtcNow;
}
namespace ListaTareasApi.Application.Abstractions.Clock;

public interface IDateTimeProvider
{
    DateTime currentTime {get;}
}
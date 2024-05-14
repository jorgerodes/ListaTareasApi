using ListaTareasApi.Domain.Abstractions;
using MediatR;


namespace ListaTareasApi.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}
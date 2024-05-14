using ListaTareasApi.Domain.Abstractions;
using MediatR;


namespace ListaTareasApi.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
 where TQuery: IQuery<TResponse>
{
    
}
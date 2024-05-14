using Dapper;
using ListaTareasApi.Application.Abstractions.Data;
using ListaTareasApi.Application.Abstractions.Messaging;
using ListaTareasApi.Domain.Abstractions;
using ListaTareasApi.Domain.Tareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTareasApi.Application.Tareas.ListaTareas
{
    internal sealed class ListaTareasQueryHandler : IQueryHandler<ListaTareasQuery, IEnumerable<TareaResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ListaTareasQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IEnumerable<TareaResponse>>> Handle(ListaTareasQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """
           SELECT
                id AS Id,
                nombre as Nombre,
                orden as Orden,
                status AS Status
               
           FROM tareas
           ORDER BY orden asc
          """;

        var tareas = await connection.QueryAsync<TareaResponse>(sql, cancellationToken);

        return tareas.ToList();

        }
    }
}

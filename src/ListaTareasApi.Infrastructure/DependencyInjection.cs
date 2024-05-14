
using ListaTareasApi.Application.Abstractions.Clock;
using ListaTareasApi.Domain.Tareas;
using ListaTareasApi.Infrastructure.Clock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using ListaTareasApi.Domain.Abstractions;
using ListaTareasApi.Application.Abstractions.Data;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ListaTareasApi.Infrastructure.Repositories;

namespace ListaTareasApi.Infrastructure
{
    public static  class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {

            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            
            var connectionString = configuration.GetConnectionString("Database")
                 ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ITareaRepository, TareaRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

            return services;
        }
    }
}

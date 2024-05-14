using ListaTareasApi.Infrastructure.Repositories;
using ListaTareasApi.Domain.Tareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ListaTareasApi.Infrastructure.Repositories
{
    internal class TareaRepository : Repository<Tarea, TareaId>, ITareaRepository
    {
        public TareaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ExisteTareaByNameAsync(Nombre name)
        {
            return await DbContext.Set<Tarea>().AnyAsync(x => x.Nombre == name);
        }
    }
}

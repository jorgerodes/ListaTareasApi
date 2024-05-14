using FluentValidation;
using ListaTareasApi.Application.Tareas.FinalizarTarea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTareasApi.Application.Empresas.CrearEmpresa
{
    public class CrearTareaCommandValidator :AbstractValidator<CrearTareaCommand>
    {
        public CrearTareaCommandValidator()
        {
            RuleFor(e => e.Nombre).NotEmpty();
            RuleFor(e => e.Orden).NotEmpty();      
        }
    }
}

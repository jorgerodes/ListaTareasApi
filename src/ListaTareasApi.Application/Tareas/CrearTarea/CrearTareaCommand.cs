using ListaTareasApi.Application.Abstractions.Messaging;
using ListaTareasApi.Domain.Tareas;
using ListaTareasApi.Application.Tareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ListaTareasApi.Application.Tareas.FinalizarTarea;

public sealed record CrearTareaCommand(string Nombre,int Orden) :ICommand<TareaResponse>;



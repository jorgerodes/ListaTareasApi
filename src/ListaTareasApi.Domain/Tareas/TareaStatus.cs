using System.ComponentModel.DataAnnotations;

namespace ListaTareasApi.Domain.Tareas;

public enum TareaStatus
{
    [Display(Name = "Pendiente")]
    Pendiente = 1,
    [Display(Name = "Hecha")]
    Hecha = 2
}


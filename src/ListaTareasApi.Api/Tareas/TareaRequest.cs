namespace ListaTareasApi.Api.Tareas
{
    public sealed record TareaRequest(string Nombre, int Orden);

    public sealed record OrdenaTareaRequest(Guid Id, int Orden);
}

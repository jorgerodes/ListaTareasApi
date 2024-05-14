namespace ListaTareasApi.Application.Abstractions.Behaviours;
public sealed record ValidationError(string PropertyName, string ErrorMessage);
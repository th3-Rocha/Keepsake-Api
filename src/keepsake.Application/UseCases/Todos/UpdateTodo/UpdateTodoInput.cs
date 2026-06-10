namespace keepsake.Application.UseCases.Todos.UpdateTodo;


public record UpdateTodoInput(
    Guid Id, string? Title, bool? IsCompleted
);

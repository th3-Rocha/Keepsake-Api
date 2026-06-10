namespace keepsake.Application.UseCases.Todos.GetTodo;


public record GetTodoOutput(
    Guid Id,
    string Title,
    bool IsCompleted,
    DateTime CreateAt,
    DateTime? CompletedAt
);

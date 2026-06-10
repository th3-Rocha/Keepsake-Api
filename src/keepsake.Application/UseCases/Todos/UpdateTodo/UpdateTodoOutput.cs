namespace keepsake.Application.UseCases.Todos.UpdateTodo;

public record UpdateTodoOutput(Guid Id, string Title, bool IsCompleted);

namespace keepsake.Application.UseCases.Todos.CreateTodo;

public record CreateTodoOutput(Guid Id, string Title, bool IsCompleted);

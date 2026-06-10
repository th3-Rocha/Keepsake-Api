using keepsake.Domain.Entities;
using keepsake.Domain.Repositories;


namespace keepsake.Application.UseCases.Todos.CreateTodo;

public class CreateTodoUseCase(ITodoRepository todoRepository)
{
    public async Task<CreateTodoOutput> ExecuteAsync(CreateTodoInput input)
    {
        var todoItem = new TodoItem(input.Title);
        await todoRepository.AddAsync(todoItem);

        return new CreateTodoOutput(todoItem.Id, todoItem.Title, todoItem.IsCompleated);
    }
}

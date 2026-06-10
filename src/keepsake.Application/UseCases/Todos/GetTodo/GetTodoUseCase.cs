using keepsake.Domain.Repositories;

namespace keepsake.Application.UseCases.Todos.GetTodo;

public class GetTodoUseCase(ITodoRepository todoRepository)
{
    public async Task<GetTodoOutput> ExecuteAync(Guid Id)
    {
        var ItemTodo = await todoRepository.GetByIdAsync(Id)
            ?? throw new Exception("not find");

        return new GetTodoOutput(ItemTodo.Id, ItemTodo.Title, ItemTodo.IsCompleated, ItemTodo.CreateAt, ItemTodo.CompletedAt);
    }
}

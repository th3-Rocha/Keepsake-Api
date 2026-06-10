using keepsake.Domain.Repositories;

namespace keepsake.Application.UseCases.Todos.DeleteTodo;

public class DeleteTodoUseCase(ITodoRepository todoRepository)
{
    public async Task<string> ExecuteAsync(Guid Id)
    {
        var ItemTodo = await todoRepository.GetByIdAsync(Id)
            ?? throw new Exception("not find");

        await todoRepository.DeleteAsync(ItemTodo);
        return "sucess";
    }
}

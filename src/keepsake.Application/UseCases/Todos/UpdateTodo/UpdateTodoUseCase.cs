using keepsake.Domain.Repositories;
using Microsoft.Extensions.Logging; // ◄ ADICIONE ESTA LINHA
namespace keepsake.Application.UseCases.Todos.UpdateTodo;

public class UpdateTodoUseCase(ITodoRepository todoRepository, ILogger<UpdateTodoUseCase> logger)
{

    public async Task<UpdateTodoOutput> ExecuteAsync(UpdateTodoInput input)
    {
        var todoItem = await todoRepository.GetByIdAsync(input.Id) ?? throw new Exception("Todo item not found");
        logger.LogInformation("Tarefa criada com sucesso: {Title}", todoItem.Title);
        if (!string.IsNullOrWhiteSpace(input.Title))
            todoItem.ChangeTitle(input.Title);

        if (input.IsCompleted == true)
            todoItem.Finish();

        if (input.IsCompleted == false)
            todoItem.UnFinished();

        await todoRepository.UpdateAsync(todoItem);

        return new UpdateTodoOutput(todoItem.Id, todoItem.Title, todoItem.IsCompleated);
    }
}

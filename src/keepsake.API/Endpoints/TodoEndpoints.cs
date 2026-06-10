using keepsake.Application.UseCases.Todos.CreateTodo;
using keepsake.Application.UseCases.Todos.GetTodo;
using keepsake.Application.UseCases.Todos.UpdateTodo;
using keepsake.Application.UseCases.Todos.DeleteTodo;
using Microsoft.AspNetCore.Mvc;

namespace keepsake.API.Endpoints;

public static class TodoEndpoints
{
    public static void MapTodoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/todos");

        // 1. POST - Criar
        group.MapPost("", async ([FromBody] CreateTodoInput input, CreateTodoUseCase useCase) =>
        {
            var output = await useCase.ExecuteAsync(input);

            return Results.Created($"/api/todos/{output.Id}", output);
        });

        // 2. GET - Buscar por ID
        group.MapGet("{id:guid}", async (Guid id, GetTodoUseCase useCase) =>
        {
            var output = await useCase.ExecuteAync(id);
            return Results.Ok(output);
        });

        // 3. PUT - Atualizar
        group.MapPut("{id:guid}", async (Guid id, [FromBody] UpdateTodoInput input, UpdateTodoUseCase useCase) =>
        {
            var inputComId = input with { Id = id };

            var output = await useCase.ExecuteAsync(inputComId);

            Console.WriteLine($"\n🚀 [DEBUG] Objeto atualizado: ID={output.Id} | Title={output.Title}");
            return Results.Ok(output);
        });

        // 4. DELETE - Deletar
        group.MapDelete("{id:guid}", async (Guid id, DeleteTodoUseCase useCase) =>
        {
            await useCase.ExecuteAsync(id);
            return Results.NoContent();
        });
    }
}

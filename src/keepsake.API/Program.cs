using keepsake.Domain.Repositories;
using keepsake.Infrastructure.Context;
using keepsake.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using keepsake.API.Endpoints;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));


builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<keepsake.Application.UseCases.Todos.CreateTodo.CreateTodoUseCase>();
builder.Services.AddScoped<keepsake.Application.UseCases.Todos.DeleteTodo.DeleteTodoUseCase>();
builder.Services.AddScoped<keepsake.Application.UseCases.Todos.GetTodo.GetTodoUseCase>();
builder.Services.AddScoped<keepsake.Application.UseCases.Todos.UpdateTodo.UpdateTodoUseCase>();

builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapTodoEndpoints();

app.Run();

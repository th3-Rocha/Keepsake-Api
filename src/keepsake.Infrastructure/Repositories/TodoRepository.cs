using keepsake.Domain.Entities;
using keepsake.Domain.Repositories;
using keepsake.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace keepsake.Infrastructure.Repositories;


public class TodoRepository(AppDbContext context) : ITodoRepository
{

    public async Task<TodoItem?> GetByIdAsync(Guid id)
    {
        return await context.TodoItems.FindAsync(id);
    }


    public async Task<IEnumerable<TodoItem>> GetAllAsync()
    {
        IQueryable<TodoItem> query = context.TodoItems;
        return await query.OrderByDescending(t => t.CreateAt).ToListAsync();
    }

    public async Task AddAsync(TodoItem todoItem)
    {
        await context.TodoItems.AddAsync(todoItem);

        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TodoItem todoItem)
    {
        context.TodoItems.Update(todoItem);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TodoItem todoItem)
    {
        context.TodoItems.Remove(todoItem);
        await context.SaveChangesAsync();
    }

}

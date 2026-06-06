using keepsake.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using keepsake.Models;

namespace keepsake.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController(AppDbContext context) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var Items = await context.TodoItems.ToListAsync();
        return Ok(Items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetOne(Guid id)
    {
        var Item = await context.TodoItems.FindAsync(id);

        if (Item == null)
        {
            return NotFound();
        }

        return Ok(Item);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOne(Guid id)
    {
        var Item = await context.TodoItems.FindAsync(id);
        if (Item == null)
        {
            return NotFound();
        }
        context.TodoItems.Remove(Item);
        await context.SaveChangesAsync();
        return Ok(Item);

    }
    [HttpPost]
    public async Task<ActionResult> PostOne([FromBody] TodoItem item)
    {
        context.TodoItems.Add(item);

        await context.SaveChangesAsync();

        return Ok(item);
    }

}

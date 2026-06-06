using Microsoft.EntityFrameworkCore;
using keepsake.Models;

namespace keepsake.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; }
}

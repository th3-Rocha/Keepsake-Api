using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace keepsake.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // Aqui nós dizemos diretamente para a ferramenta do EF usar o Postgres do seu Docker
        optionsBuilder.UseNpgsql("Host=localhost;Port=5632;Database=mydatabase;Username=user;Password=password");

        return new AppDbContext(optionsBuilder.Options);
    }
}

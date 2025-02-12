using Microsoft.EntityFrameworkCore;
using WebAppDocker.Database.Entities;

namespace WebAppDocker.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using WebAppDockerDbContext dbContext = scope.ServiceProvider.GetRequiredService<WebAppDockerDbContext>();
            dbContext.Database.Migrate();
        }
    }
}

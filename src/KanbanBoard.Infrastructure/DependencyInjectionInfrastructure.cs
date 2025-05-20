using KanbanBoard.Application.Interfaces.Repositories;
using KanbanBoard.Infrastructure.Persistence.Contexts;
using KanbanBoard.Infrastructure.Persistence.Repositories;
using KanbanBoard.Infrastructure.Persistence.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KanbanBoard.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Ensure the DbContext is registered with the correct options
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            // Register IRepository and its implementation
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }

        public static async Task EnsureSeedDataAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await DataSeeder.SeedAsync(context);
            }
        }
    }
}

using Domain.Interface;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Service
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<CamadasContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:ServerConnection",
                x => x.MigrationsAssembly("Infrastructure")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<CamadasContext>>();
            using (var dbContext = new CamadasContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}

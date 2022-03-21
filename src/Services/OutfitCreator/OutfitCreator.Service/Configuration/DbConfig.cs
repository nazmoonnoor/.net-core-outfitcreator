using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutfitCreator.Infrastructure;

namespace OutfitCreator.Service.Configuration
{
    public static class DbConfig
    {
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration Configuration)
        {
            // Configure Entityframework core with SQL Server
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void ConfigureSqlite(this IServiceCollection services, IConfiguration Configuration)
        {
            // Configure Entityframework core with Sqlite
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlite(Configuration.GetConnectionString("SqliteConnection"));
            });
        }
    }
}

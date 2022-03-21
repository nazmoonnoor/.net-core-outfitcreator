using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutfitCreator.Core.Repository;
using OutfitCreator.Services;

namespace OutfitCreator.Service.Configuration
{
    public static class DependencyConfig
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration config)
        {
            //
            // Service layer
            services.AddTransient<ITokenBuilder, TokenBuilder>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductImageService, ProductImageService>();

            //
            //  Storage layer
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<IProductGroupRepository, ProductGroupRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();

        }

    }
}

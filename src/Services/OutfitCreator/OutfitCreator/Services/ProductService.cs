using Domain = OutfitCreator.Core.Domain;
using OutfitCreator.QueryFilters;
using System;
using System.Threading.Tasks;
using OutfitCreator.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using OutfitCreator.SharedKernel;
using OutfitCreator.Core.Domain;

namespace OutfitCreator.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ICountryRepository countryRepository;

        public ProductService(IProductRepository productRepository, ICountryRepository countryRepository)
        {
            this.productRepository = productRepository;
            this.countryRepository = countryRepository;
        }
        public async Task<Domain.Product> SearchProduct(ProductFilter query)
        {
            if (query == null || string.IsNullOrEmpty(query.ProductCode))
                throw new ArgumentNullException("Product Identifier cannot be empty");
            if (query == null || string.IsNullOrEmpty(query.Country))
                throw new ArgumentNullException("Country code cannot be empty");

            try
            {
                var country = await countryRepository.GetByCodeAsync(query.Country.ToUpper());
                
                if (country == null)
                    throw new ArgumentNullException("Invalid Country code");

                var product = await productRepository.GetByCodeAsync(query.ProductCode, country.Id);
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task<List<Domain.Product>> SearchProductByGroups(ProductGroupFilter query)
        {
            if (query == null || string.IsNullOrEmpty(query.Gender))
                throw new ArgumentNullException("Gender cannot be empty");
            if (query == null || string.IsNullOrEmpty(query.Country))
                throw new ArgumentNullException("Country code cannot be empty");
            if(query.WebCategories.Length < 1)
                throw new ArgumentNullException("WebCategories cannot be empty");

            try
            {
                var country = await countryRepository.GetByCodeAsync(query.Country.ToUpper());
                if(country == null)
                    throw new ArgumentException("Invalid country");

                string[] webCategories = query.WebCategories.Split(',').Select(p => p.Trim()).ToArray();
                Gender domainGender = EnumUtil.ParseEnum<Gender>(query.Gender);

                var products = await productRepository.GetByGroupAsync(webCategories, country.Id, domainGender);
                
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
}

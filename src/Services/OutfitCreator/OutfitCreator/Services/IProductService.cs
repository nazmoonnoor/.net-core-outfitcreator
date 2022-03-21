using Domain = OutfitCreator.Core.Domain;
using OutfitCreator.QueryFilters;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Services
{
    public interface IProductService
    {
        Task<Domain.Product> SearchProduct(ProductFilter query);
        Task<List<Domain.Product>> SearchProductByGroups(ProductGroupFilter query);
    }
}

using Domain = OutfitCreator.Core.Domain;
using OutfitCreator.QueryFilters;
using System.Threading.Tasks;

namespace OutfitCreator.Services
{
    public interface IProductImageService
    {
        Task<Domain.ProductImage> SearchProductImage(ProductImageFilter query);
    }
}

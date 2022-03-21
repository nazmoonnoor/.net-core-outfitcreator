using OutfitCreator.Model;
using OutfitCreator.QueryFilters;
using System.Threading.Tasks;

namespace OutfitCreator.Services
{
    public interface IImageService
    {
        Task<Product> SearchImage(ProductImageFilter query);
    }
}

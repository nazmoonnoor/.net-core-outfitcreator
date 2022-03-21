using OutfitCreator.QueryFilters;
using System.Threading.Tasks;
using OutfitCreator.Core.Domain;
using OutfitCreator.Core.Repository;
using System;

namespace OutfitCreator.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository productImageRepository;

        public ProductImageService(IProductImageRepository productImageRepository)
        {
            this.productImageRepository = productImageRepository;
        }

        public async Task<ProductImage> SearchProductImage(ProductImageFilter query)
        {
            if (query == null || string.IsNullOrEmpty(query.ImageId))
                throw new ArgumentNullException("Image Name cannot be empty");
            if (query == null || string.IsNullOrEmpty(query.Resolution))
                throw new ArgumentNullException("Resolution cannot be empty");
            if (query == null || string.IsNullOrEmpty(query.Frame))
                throw new ArgumentNullException("Frame cannot be empty");

            // Removes file extension
            var imageId = query.ImageId.Split('.')[0];

            try
            {
                var image = await productImageRepository.SearchImageAsync(new Guid(imageId), query.Resolution, query.Frame);

                return image;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutfitCreator.QueryFilters;
using OutfitCreator.Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace OutfitCreator.Service.Api
{
    [Route("csp/images/image/public")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<ImageController> logger;
        private readonly IMapper mapper;
        private readonly IProductImageService productImageService;

        public ImageController(ILogger<ImageController> logger, IMapper mapper, IProductImageService productImageService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.productImageService = productImageService;
        }


        // https://api.newyorker.de/csp/images/image/public/7cd1b6608654321666c34e7fc38aede6.png?res=high&frame=2_3
        [HttpGet("{imageId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Model.Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(string imageId, [FromQuery(Name = "res")] string resolution, [FromQuery(Name = "frame")] string frame)
        {
            if (imageId == null)
                return BadRequest();

            var query = new ProductImageFilter
            {
                ImageId = imageId,
                Resolution = resolution,
                Frame = frame
            };

            var product = await productImageService.SearchProductImage(query);

            // For development purposes, it returns a same generic image.
            var image = System.IO.File.OpenRead(product.ImageUrl);
            return File(image, "image/jpeg");
        }
    }
}

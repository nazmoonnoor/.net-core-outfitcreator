using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutfitCreator.Core;
using OutfitCreator.Model;
using OutfitCreator.QueryFilters;
using OutfitCreator.Services;
using OutfitCreator.SharedKernel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Model = OutfitCreator.Model;

namespace OutfitCreator.Service.Api
{
    [Route("csp/products/public")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IMapper mapper;
        private readonly IProductService productService;

        public ProductController(ILogger<ProductController> logger, IMapper mapper, IProductService productService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.productService = productService;
        }

        // https://api.newyorker.de/csp/products/public/product/06.04.101.1636?country=de
        /// <summary>
        /// Retrieve product by id and country
        /// </summary>
        /// <param name="id">Game bet identifier</param>
        /// <returns>If exist, it returns the bet</returns>
        [HttpGet("product/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Model.Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(string id, string country)
        {
            if(string.IsNullOrEmpty(id))
                return BadRequest();

            var productQuery = new ProductFilter
            {
                ProductCode = id,
                Country = country
            };

            var product = await productService.SearchProduct(productQuery);
            
            return Ok(mapper.Map<Model.Product>(product));
        }

        // https://api.newyorker.de/csp/products/public/query?filters[country]=de&filters[gender]=FEMALE&filters[web_category]=Accessoires, WCA01156, WCA01159, WCA01155, WCA01152, WCA01158, WCA01153, WCA01157, WCA01154

        [HttpGet("query")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IList<Model.Product>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Filter([FromQuery(Name = "filters[country]")] string country, [FromQuery(Name = "filters[gender]")] string gender,
            [FromQuery(Name = "filters[web_category]")] string web_category)
        {
            if (string.IsNullOrEmpty(web_category))
                return BadRequest();

            var countryCode = country;
            var genderCode = gender;
            var webCategories = web_category;


            var productQuery = new ProductGroupFilter
            {
                Gender = genderCode,
                Country = countryCode,
                WebCategories = webCategories
            };

            var product = await productService.SearchProductByGroups(productQuery);

            return Ok(mapper.Map<List<Model.Product>>(product));
        }
    }
}

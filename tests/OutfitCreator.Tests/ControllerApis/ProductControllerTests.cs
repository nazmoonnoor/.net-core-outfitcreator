using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using OutfitCreator.QueryFilters;
using OutfitCreator.Service.Api;
using OutfitCreator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OutfitCreator.Tests.ControllerApis
{
    public class ProductControllerTests : IDisposable
    {
        private APIWebApplicationFactory _factory;
        private HttpClient _client;

        public ProductControllerTests()
        {
            _factory = new APIWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task WhenGetProduct_ThenTheResultIsOk()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(repo => repo.SearchProduct(It.IsAny<ProductFilter>()))
                .Returns(Task.FromResult(new Core.Domain.Product {  }));

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Core.Domain.Product>(It.IsAny<Model.Product>()))
                .Returns(new Core.Domain.Product {  });

            mockMapper.Setup(x => x.Map<Model.Product>(It.IsAny<Core.Domain.Product>()))
                .Returns(new Model.Product {  });


            var mockLogger = new Mock<ILogger<ProductController>>();
            mockLogger.Setup(x => x.Log(
                            It.IsAny<LogLevel>(),
                            It.IsAny<EventId>(),
                            It.IsAny<It.IsAnyType>(),
                            It.IsAny<Exception>(),
                            (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

            var controller = new ProductController(mockLogger.Object, mockMapper.Object, mockService.Object);

            // Act
            var result = await controller.Get("123", "de");

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task WhenGetEmptyProductId_ThenTheResultIsBadRequest()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(repo => repo.SearchProduct(It.IsAny<ProductFilter>()))
                .Returns(Task.FromResult(new Core.Domain.Product { }));

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Core.Domain.Product>(It.IsAny<Model.Product>()))
                .Returns(new Core.Domain.Product { });

            mockMapper.Setup(x => x.Map<Model.Product>(It.IsAny<Core.Domain.Product>()))
                .Returns(new Model.Product { });


            var mockLogger = new Mock<ILogger<ProductController>>();
            mockLogger.Setup(x => x.Log(
                            It.IsAny<LogLevel>(),
                            It.IsAny<EventId>(),
                            It.IsAny<It.IsAnyType>(),
                            It.IsAny<Exception>(),
                            (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

            var controller = new ProductController(mockLogger.Object, mockMapper.Object, mockService.Object);

            // Act
            var result = await controller.Get("", "de");

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task WhenFilterProduct_ThenTheResultIsOk()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(repo => repo.SearchProduct(It.IsAny<ProductFilter>()))
                .Returns(Task.FromResult(new Core.Domain.Product { }));

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Core.Domain.Product>(It.IsAny<Model.Product>()))
                .Returns(new Core.Domain.Product { });

            mockMapper.Setup(x => x.Map<Model.Product>(It.IsAny<Core.Domain.Product>()))
                .Returns(new Model.Product { });


            var mockLogger = new Mock<ILogger<ProductController>>();
            mockLogger.Setup(x => x.Log(
                            It.IsAny<LogLevel>(),
                            It.IsAny<EventId>(),
                            It.IsAny<It.IsAnyType>(),
                            It.IsAny<Exception>(),
                            (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

            var controller = new ProductController(mockLogger.Object, mockMapper.Object, mockService.Object);

            // Act
            var result = await controller.Filter("de", "MALE", "web_category");

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task WhenFilterEmptyWebCategory_ThenTheResultIsBadRequest()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(repo => repo.SearchProduct(It.IsAny<ProductFilter>()))
                .Returns(Task.FromResult(new Core.Domain.Product { }));

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Core.Domain.Product>(It.IsAny<Model.Product>()))
                .Returns(new Core.Domain.Product { });

            mockMapper.Setup(x => x.Map<Model.Product>(It.IsAny<Core.Domain.Product>()))
                .Returns(new Model.Product { });


            var mockLogger = new Mock<ILogger<ProductController>>();
            mockLogger.Setup(x => x.Log(
                            It.IsAny<LogLevel>(),
                            It.IsAny<EventId>(),
                            It.IsAny<It.IsAnyType>(),
                            It.IsAny<Exception>(),
                            (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

            var controller = new ProductController(mockLogger.Object, mockMapper.Object, mockService.Object);

            // Act
            var result = await controller.Filter("de", "MALE", "");

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }


        public void Dispose()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Moq;
using OutfitCreator.Service.Api;
using OutfitCreator.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace OutfitCreator.Tests.ControllerApis
{
    public class AuthControllerTests : IDisposable
    {
        private APIWebApplicationFactory _factory;
        private HttpClient _client;

        public AuthControllerTests()
        {
            _factory = new APIWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task WhenRegistrationPayloadIsPosted_ThenTheResultIsOk()
        {
            // Arrange
            var mockRepo = new Mock<IUserManager>();
            mockRepo.Setup(repo => repo.RegisterUserAsync(It.IsAny<RegisterModel>()))
                .Returns(Task.FromResult(new UserManagerResponse
                {
                    IsSuccess = true
                }));

            var controller = new AuthController(mockRepo.Object);
            var payload = new RegisterModel
            {
                Email = "smith@gmail.com",
                Password = "Aa@1234",
                ConfirmPassword = "Aa@1234",
                Name = "Smith"
            };

            // Act
            var result = await controller.RegisterAsync(payload);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task WhenRegistrationPayloadIsNotOkay_ThenTheResultIsBadRequest()
        {
            // Arrange
            var mockRepo = new Mock<IUserManager>();
            mockRepo.Setup(repo => repo.RegisterUserAsync(It.IsAny<RegisterModel>()))
                .Returns(Task.FromResult(new UserManagerResponse
                {
                }));

            var controller = new AuthController(mockRepo.Object);

            // Act + Assert
            Assert.IsType<BadRequestObjectResult>(await controller.RegisterAsync(new RegisterModel
            {
                Password = "Aa@1234",
                ConfirmPassword = "Aa@1234",
                Name = "Smith"
            }));
        }

        public void Dispose()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}

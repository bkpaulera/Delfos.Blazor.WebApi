using Delfos.Domain.Models;
using Delfos.Test.Xunit.Factory;
using System.Net;
using System.Net.Http.Json;

namespace Delfos.Test.Xunit.Controllers
{
    [Collection("Databases")]
    public class PlayerControllerTests : IClassFixture<TestFactory>
    {
        private readonly TestFactory _factory;

        public PlayerControllerTests(TestFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetPlayer()
        {
            //Arrange
            var client = _factory.CreateClient();
            //Act
            var response = await client.GetAsync("GetPlayer");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task PostPlayer()
        {
            //Arrange
            var client = _factory.CreateClient();
            //Act
            var request = new PlayersModel { Id = 1, Name = "Paulo" };

            var response = await client.PostAsJsonAsync("CreatePlayer", request);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

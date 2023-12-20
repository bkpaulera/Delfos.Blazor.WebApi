using Delfos.Test.Xunit.Fixture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Delfos.Test.Xunit.Factory
{
    [Collection("Databases")]
    public class TestFactory : WebApplicationFactory<Program>
    {
        private readonly DbFixture _fixture;

        public TestFactory(DbFixture dbFixture)
        {
            _fixture = dbFixture;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");

            builder.ConfigureServices(services =>
            {
            });

            builder.ConfigureAppConfiguration((context, configuration) =>
            {
                configuration.AddInMemoryCollection(new[]
                {
                new KeyValuePair<string, string>("ConnectionStrings:DefaultConnection", _fixture.ConnectionString)
            });
            });
        }
    }

}

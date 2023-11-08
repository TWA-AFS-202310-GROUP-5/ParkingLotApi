using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Services;

namespace ParkingLotApiTest
{
    public class TestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        public TestBase(WebApplicationFactory<Program> factory)
        {
            Factory = factory;
        }

        public WebApplicationFactory<Program> Factory { get; }

        protected HttpClient GetClient()
        {
            return Factory.CreateClient();
        }
    }
}

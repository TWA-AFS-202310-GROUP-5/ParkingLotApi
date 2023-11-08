using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace ParkingLotApiTest
{
    public class WeatherForecastControllerTest : TestBase
    {
        private HttpClient _httpClient;

        public WeatherForecastControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
            _httpClient = GetClient();
        }

        [Fact]
        public async Task Should_return_correctly_when_get_weather_forecast()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/WeatherForecast");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecastControllerTest
    {
        private HttpClient _httpClient;
        public WeatherForecastControllerTest()
        {
            WebApplicationFactory<Program> factory = new WebApplicationFactory<Program>();
            _httpClient = factory.CreateClient(); 
        }

        [Fact]
        public async Task Should_return_correctly_when_get_weather_forecast()
        {
            //given
            HttpResponseMessage response = await _httpClient.GetAsync("/WeatherForecast");

            //then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

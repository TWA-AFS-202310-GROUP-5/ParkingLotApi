using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForcastControllerTest:TestBase
    {
        private HttpClient _httpClient;

        public WeatherForcastControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        { 
        }
        [Fact]
        public async Task Should_return_correctly_when_get_weather_forecast()
        {
            // given & when
            HttpClient _httpClient = GetClient(); 
            HttpResponseMessage response = await _httpClient.GetAsync("/weatherForecast");
            // then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

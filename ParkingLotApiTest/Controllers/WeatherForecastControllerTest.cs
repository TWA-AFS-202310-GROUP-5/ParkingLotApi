﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class WeatherForecastControllerTest: TestBase
    {
        public WeatherForecastControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        { 
        }

        [Fact]
        public async Task Should_return_correct_forecast_when_get_weather_forecast()
        {
            HttpClient client = GetClient();
            var reponse = await client.GetAsync("/WeatherForecast");

            Assert.Equal(HttpStatusCode.OK, reponse.StatusCode);
        }
    }
}

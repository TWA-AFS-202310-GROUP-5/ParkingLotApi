using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotApiControllerTest : TestBase
    {
        private HttpClient _httpClient;

        public ParkingLotApiControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
            _httpClient = GetClient();
        }

        [Fact]
        public async Task Should_return_400_when_create_parkinglot_given_capacity_less_than_10()
        {
            ParkingLotDto parkingLotDto = new ParkingLotDto { Name = "AC Parking Structure", Capacity = 5, Location = "23 W Main St, Los Angeles, CA" };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<ParkingLotDto>("/api/ParkingLots", parkingLotDto);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Should_return_400_when_create_parkinglot_given_existed_name()
        {
            ParkingLotDto parkingLotDto = new ParkingLotDto { Name = "AC Parking Structure", Capacity = 10, Location = "23 W Main St, Los Angeles, CA" };
            await _httpClient.PostAsJsonAsync<ParkingLotDto>("/api/ParkingLots", parkingLotDto);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<ParkingLotDto>("/api/ParkingLots", parkingLotDto);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

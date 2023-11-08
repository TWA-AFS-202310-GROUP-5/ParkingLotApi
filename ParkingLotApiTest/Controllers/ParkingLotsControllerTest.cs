using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotsControllerTest : TestBase
    {
        private HttpClient _httpClient;

        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
            _httpClient = GetClient();
        }

        [Fact]
        public async Task Should_return_400_when_create_parkinglot_given_capacity_less_than_10()
        {
            ParkingLotRequest parkingLotDto = new ParkingLotRequest { Name = "AC Parking Structure", Capacity = 5, Location = "23 W Main St, Los Angeles, CA" };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<ParkingLotRequest>("/api/ParkingLots", parkingLotDto);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Should_return_400_when_create_parkinglot_given_existed_name()
        {
            ParkingLotRequest parkingLotDto = new ParkingLotRequest { Name = "AC Parking Structure", Capacity = 10, Location = "23 W Main St, Los Angeles, CA" };
            await _httpClient.PostAsJsonAsync<ParkingLotRequest>("/api/ParkingLots", parkingLotDto);

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<ParkingLotRequest>("/api/ParkingLots", parkingLotDto);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

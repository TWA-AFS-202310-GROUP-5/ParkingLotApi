using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotsControllerTest:TestBase
    {
        private HttpClient _httpClient;

        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        { 
        }
        [Fact]
        public async Task Should_return_400_when_create_parking_lot_given_capacity_less_than_10()
        {
            // given & 
            HttpClient _httpClient = GetClient();
            ParkingLotDto parkingLotDtoWithCapacityLessThan10 = new ParkingLotDto()
            {
                Name = "best park",
                Capacity = 9,
                Location = "TS Building A",
            };
            //when
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/ParkingLots", parkingLotDtoWithCapacityLessThan10);
            // then
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

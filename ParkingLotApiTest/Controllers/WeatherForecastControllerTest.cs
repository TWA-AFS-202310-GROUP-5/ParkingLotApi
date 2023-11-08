using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }
        [Fact]
        public async Task Should_return_400_when_create_parking_lot_given_capacity_less_than_10()
        {
            // given
            var parkingLot = new ParkingLotDto(){Name = "Parking Lot 1", Capacity = 9, Location = "Street 1"};
            var client = GetClient();
            // when
            var response =await client.PostAsJsonAsync("api/parkingLots", parkingLot);
            // then
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

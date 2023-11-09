using Microsoft.AspNetCore.Mvc.Testing;
using ParkingLotApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApiTest.Controllers
{
    public class ParkingLotsControllerTest : TestBase
    {
        public ParkingLotsControllerTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_return_400_when_create_parkinglot_given_capacity_less_than_10()
        {
            //given
            ParkingLotDto parkingLotWithCapacityLessThan10 = new ParkingLotDto()
            {
                Name = "parkingNo1",
                Capacity = 2,
                Location = "C1"
            };

            HttpClient httpClient = GetClient();   
        
            //when
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("/ParkingLots", parkingLotWithCapacityLessThan10);

            //then
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("/parkinglots")]
    public class ParkingLotController : Controller
    {
        
        [HttpPost]
        public async Task<ActionResult<ParkingLot>> AddParkingLotAsync([FromBody]ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                return BadRequest();
            }
            return null;
        }
    }
}

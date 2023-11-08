using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ParkingLot>> AddParkingLot([FromBody] ParkingLotRequest parkingLot)
        {
            if (parkingLot.Capacity < 10)
            {
                return BadRequest();
            }
            return Ok(parkingLot);
        }
    }
}

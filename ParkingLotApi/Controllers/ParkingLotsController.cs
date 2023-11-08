using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;



namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        [HttpPost(Name = "to create a new parking lot")]
        public async Task<ActionResult<ParkingLotDto>> AddParkingLot([FromBody]ParkingLotDto parkingLot)
        {   
            if (parkingLot.Capacity < 10)
            {
                return BadRequest();
            }
            return parkingLot;
        }
    }
}

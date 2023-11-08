using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsService _parkingLotsService = null!;

        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            this._parkingLotsService = parkingLotsService;
        }

        [HttpPost(Name = "to create a new parking lot")]
        public async Task<ActionResult<ParkingLotDto>> AddParkingLot([FromBody]ParkingLotDto parkingLot)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLot));
            }
            catch (InvalidCapacityException ex) {
                return BadRequest();
            }
            
        }
    }
}

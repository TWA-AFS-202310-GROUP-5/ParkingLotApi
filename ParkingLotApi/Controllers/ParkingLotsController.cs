using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("api/parkingLots")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotService _parkingLotService;
        public ParkingLotsController(ParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> CreateParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            return StatusCode(StatusCodes.Status201Created, await _parkingLotService.AddSync(parkingLotDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOneParkingLotAsync(string id)
        {
            await _parkingLotService.DeleteOneParkingLotAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }

    }
}

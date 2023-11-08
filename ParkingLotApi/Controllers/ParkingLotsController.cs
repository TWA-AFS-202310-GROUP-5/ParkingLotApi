using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsService _parkingLotsService;
        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            this._parkingLotsService = parkingLotsService;
        }
        [HttpPost]
        public async Task<ActionResult<ParkingLot>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLotDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveParkingLotById(string id)
        {
            await _parkingLotsService.DeleteByIdAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLots(string pageIndex)
        {
            return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetParkingLotsAsync(Int32.Parse(pageIndex)));
        }

    }
}

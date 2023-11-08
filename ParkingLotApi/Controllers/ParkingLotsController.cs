using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;
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

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> AddParkingLot([FromBody] ParkingLotDto parkingLot)
        {
            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLot));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot?>> GetById(string id)
        {
            return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetById(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot?>>> GetPage([FromQuery] int pageIndex)
        {
            return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetPage(pageIndex));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(string id)
        {
            await _parkingLotsService.DeleteById(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingLot>> UpdateCapacity(string id, CapacityRequest capacity)
        {
            return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.UpdateCapacity(id, capacity));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsService parkingLotsService;

        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            this.parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> AddParkingLotAsync([FromBody] ParkingLotRequest parkingLot)
        {
            return StatusCode(StatusCodes.Status201Created, await parkingLotsService.AddAsync(parkingLot));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteParkingLot([FromRoute] string id)
        {
            parkingLotsService.DeleteParkingLotAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotAsync([FromQuery] int pageIndex = 1)
        {
            return Ok(await parkingLotsService.GetParkingLotWithPageIndexAsync(pageIndex));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotByIdAsync([FromRoute] string id)
        {
            return Ok(await parkingLotsService.GetParkingLotByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ParkingLot>>> UpdateParkingLotCapacity([FromRoute] string id, [FromBody] CapacityDto capacityDto)
        {
            return Ok(await parkingLotsService.UpdateParkingLotCapacity(id, capacityDto.Capacity));
        }
    }
}

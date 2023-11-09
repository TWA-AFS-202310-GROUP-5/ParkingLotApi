using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
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
        public async Task<ActionResult<ParkingLot>> CreateParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            return StatusCode(StatusCodes.Status201Created, await _parkingLotService.AddSync(parkingLotDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOneParkingLotAsync(string id)
        {
            await _parkingLotService.DeleteOneParkingLotAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot>> GetOneParkingLotByIdAsync(string id)
        {
            var result = await _parkingLotService.GetOneParkingLotByIdAsync(id);
            return result != null ? StatusCode(StatusCodes.Status200OK, result) : StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpGet("pages/{pageIndex}")]
        public  ActionResult<List<ParkingLot>> GetOnePageParkingLots(int pageIndex)
        {
            return _parkingLotService.GetOnePageParkingLots(pageIndex);
        }

        [HttpPut]
        public async Task<ActionResult<ParkingLot>> UpdateOneAsync(UpdateParkingLotDto updateParkingLotDto)
        {
            var result = await _parkingLotService.GetOneParkingLotByIdAsync(updateParkingLotDto.Id);
            if (result == null)
            {
               return StatusCode(StatusCodes.Status404NotFound);
            }

            return await _parkingLotService.UpdateOneAsync(updateParkingLotDto);
        }
    }
}

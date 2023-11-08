using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("/parkinglots")]
    public class ParkingLotController : Controller
    {
        private readonly ParkingLotService _parkingLotervice;
        public ParkingLotController(ParkingLotService parkingLotService)
        {
            this._parkingLotervice = parkingLotService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> AddParkingLotAsync([FromBody]ParkingLotDto parkingLotDto)
        {
            try
            {
                return Created(nameof(AddParkingLotAsync), await _parkingLotervice.AddAsync(parkingLotDto));
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            
        }
    }
}

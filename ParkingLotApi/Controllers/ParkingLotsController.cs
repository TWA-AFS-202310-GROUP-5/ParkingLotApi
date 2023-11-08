using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;
using System.Net;
using System.Net.Sockets;

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
            try
            {
                return StatusCode(StatusCodes.Status201Created, await parkingLotsService.AddAsync(parkingLot));
            }
            catch (InvalidCapacityException)
            {
                return BadRequest();
            }
        }
    }
}

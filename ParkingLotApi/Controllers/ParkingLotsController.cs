﻿using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
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
        public async Task<ActionResult<ParkingLotDto>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLotDto));
            }
            catch (InvalidCapacityException)
            {
                return BadRequest();
            }

            return null;
        }
    }
}

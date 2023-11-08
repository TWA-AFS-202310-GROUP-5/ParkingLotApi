using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        public async Task<ParkingLotDto> AddAsync(ParkingLotDto parkingLot)
        {
            if (parkingLot.Capacity < 10 || parkingLot.Location == null)
            {
                throw new InvalidCapacityException();
            }
            return null;
        }


    }
}

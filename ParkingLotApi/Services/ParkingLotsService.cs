using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        public async Task<ParkingLotDto> AddAsync(ParkingLotDto parkingLot)
        {
            if (parkingLot.Capacity < 10 || parkingLot.Location == null)
            {
                throw new ArgumentException();
            }
            return null;
        }


    }
}

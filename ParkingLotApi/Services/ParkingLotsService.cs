﻿using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        public async Task<ParkingLot> AddAsync(ParkingLotRequest parkingLot)
        {
            if (parkingLot.Capacity < 10)
            {
                throw new InvalidCapacityException("Parking Lot Capacity cant be less than 10");
            }
            return null;
        }
    }
}
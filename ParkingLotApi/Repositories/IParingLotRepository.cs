﻿using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParingLotRepository
    {
        Task<ParkingLot> CreateParkingLotAsync(ParkingLot parkingLot);
        Task DeleteOneParkingLotAsync(string id);
        Task<ParkingLot> GetOneParkingLotById(string id);
        List<ParkingLot> GetOnePageParkingLots(int pageIndex);
        Task<ActionResult<ParkingLot>> UpdateOne(UpdateParkingLotDto updateParkingLotDto);
    }
}

using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParingLotRepository
    {
        Task<ParkingLot> CreateParkingLotAsync(ParkingLot parkingLot);
        Task DeleteOneParkingLotAsync(string id);
    }
}

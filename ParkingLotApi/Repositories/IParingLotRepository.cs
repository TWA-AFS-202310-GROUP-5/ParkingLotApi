using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParingLotRepository
    {
        Task<ParkingLot> CreateParkingLotAsync(ParkingLot parkingLot);
    }
}

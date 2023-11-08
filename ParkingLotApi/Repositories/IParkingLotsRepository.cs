using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLotAsync(ParkingLot parkingLot);
        public Task<ParkingLot> GetParkingLotByNameAsync(string name);
        public Task DeleteParkingLotAsync(string id);
    }
}

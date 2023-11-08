using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task<ParkingLot> UpdateParkingLotById(string id);
        public Task DeleteParkingLotById(string id);
        public Task<ParkingLot> GetParkingLotById(string id);
        public Task<List<ParkingLot>> GetParkingLotsInRange(int pageIndex);

    }
}

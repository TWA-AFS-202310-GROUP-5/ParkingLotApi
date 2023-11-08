using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task<ParkingLot> GetById(string id);
        //public Task<List<ParkingLot>> GetAll();

        //public Task DeleteByName(string id);
        //public Task UpdateCapacityAsync(string id, int capacity);
    }
}

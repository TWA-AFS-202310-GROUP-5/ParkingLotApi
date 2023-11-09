using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task<ParkingLot> GetById(string id);
        //public Task<List<ParkingLot>> GetAll();
        public Task<List<ParkingLot?>> GetPage(int pageIndex);
        public Task DeleteById(string id);
        public Task<ParkingLot> UpdateCapacity(string id, CapacityRequest capacity);
    }
}

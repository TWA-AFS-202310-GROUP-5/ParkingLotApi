using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLotAsync(ParkingLot parkingLot);
        public Task<ParkingLot> GetParkingLotByNameAsync(string name);
        public Task<ParkingLot> GetParkingLotByIdAsync(string id);
        public void DeleteParkingLot(string id);
        public List<ParkingLot> GetParkingLotWithPageSizePageIndex(int pageSize, int pageIndex);
    }
}

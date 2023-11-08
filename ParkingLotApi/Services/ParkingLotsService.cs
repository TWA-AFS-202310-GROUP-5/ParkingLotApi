using MongoDB.Bson;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotsRepository parkingLotsRepository;

        public ParkingLotsService(IParkingLotsRepository parkingLotsRepository)
        {
            this.parkingLotsRepository = parkingLotsRepository;
        }

        public async Task<ParkingLot> AddAsync(ParkingLotRequest parkingLot)
        {
            if (parkingLot.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            if (parkingLotsRepository.GetParkingLotByNameAsync(parkingLot.Name).Result is not null)
            {
                throw new ParkingLotAlreadyExistException();
            }
            return await parkingLotsRepository.CreateParkingLotAsync(parkingLot.ToParkingLot());
        }

        public void DeleteParkingLotAsync(string id)
        {
            parkingLotsRepository.DeleteParkingLot(id);
        }

        public List<ParkingLot> GetParkingLotWithPageIndex(int pageIndex)
        {
            return parkingLotsRepository.GetParkingLotWithPageSizePageIndex(15, pageIndex);
        }

        public Task<ParkingLot> GetParkingLotByIdAsync(string id)
        {
            if (ObjectId.TryParse(id, out _))
            {
                var parkingLot = parkingLotsRepository.GetParkingLotByIdAsync(id);
                if (parkingLot is not null)
                {
                    return parkingLot;
                }
            }
            throw new InvalidIdException();
        }
    }
}

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

        public async Task<List<ParkingLot>> GetParkingLotWithPageIndexAsync(int pageIndex)
        {
            int pageSize = 15;
            return pageIndex > 0 ? await parkingLotsRepository.GetParkingLotWithPageSizePageIndex(pageSize, pageIndex) : new List<ParkingLot>();
        }

        public async Task<ParkingLot> GetParkingLotByIdAsync(string id)
        {
            if (isValidId(id))
            {
                var parkingLot = await parkingLotsRepository.GetParkingLotByIdAsync(id);
                if (parkingLot is not null)
                {
                    return parkingLot;
                }
            }
            throw new InvalidIdException();
        }

        public async Task<ParkingLot> UpdateParkingLotCapacity(string id, int capacity)
        {
            if (capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            if (isValidId(id))
            {
                var parkingLot = await parkingLotsRepository.GetParkingLotByIdAsync(id);
                if (parkingLot is not null)
                {
                    parkingLot.Capacity = capacity;
                    return await parkingLotsRepository.UpdateParkingLotAsync(id, parkingLot);
                }
            }
            throw new InvalidIdException();
        }

        private bool isValidId(string id)
        {
            return ObjectId.TryParse(id, out _);
        }
    }
}

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

        public async Task DeleteParkingLotAsync(string id)
        {
            await parkingLotsRepository.DeleteParkingLotAsync(id);
        }
    }
}

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
            if (parkingLotsRepository.GetParkingLotByName(parkingLot.Name) is not null)
            {
                throw new ParkingLotAlreadyExistException();
            }
            return await parkingLotsRepository.CreateParkingLot(parkingLot.ToParkingLot());
        }
    }
}

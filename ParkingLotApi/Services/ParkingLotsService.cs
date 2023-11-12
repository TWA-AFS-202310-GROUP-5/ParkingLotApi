using ParkingLotApi.Dtos;
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

        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            if (parkingLotsRepository.GetParkingLotByName(parkingLotDto.Name) == null)
            {
                throw new InValidNameException();
            }
            return await parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
        }

        public async Task DeleteByIdAsync(string id)
        {
            await parkingLotsRepository.DeleteById(id);
        }

        public async Task<List<ParkingLot>> GetParkingLotsAsync(int pageIndex)
        {
            return await parkingLotsRepository.GetParkingLots(pageIndex);
        }

        public async Task<ParkingLot> GetByIdAsync(string id)
        {
            ParkingLot parkingLot = await parkingLotsRepository.GetParkingLotById(id);  
            //if (parkingLot == null)
            //{
            //    throw new NoExistIdException();
            //}
            return parkingLot;
        }

        public async Task<ParkingLot> UpdateByIdAsync(string id, UpdateRequest request)
        {
            await GetByIdAsync(id);
            return await parkingLotsRepository.UpdateParkingLotById(id, request);
        }
    }
}

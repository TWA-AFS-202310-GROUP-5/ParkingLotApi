using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        public ParkingLotService(IParkingLotRepository repository)
        {
            this._parkingLotRepository = repository;
        }

        private readonly IParkingLotRepository _parkingLotRepository;

        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            var parkingLot = new ParkingLot()
            {
                Name = parkingLotDto.Name,
                Location = parkingLotDto.Location,
                Capacity = parkingLotDto.Capacity,
            };
            return await _parkingLotRepository.CreateParkingLot(parkingLot);
        }

        public async Task DeleteParkingLotByIdAsync(string id)
        {
            if (await _parkingLotRepository.GetParkingLotById(id) != null)
            {
                await _parkingLotRepository.DeleteParkingLotById(id);
            }
            else
            {
                throw new IDNotExistException();
            }
            
        }

        public async Task<List<ParkingLot>> GetParkingLotByPageAsync(int pageIndex)
        {
            return await _parkingLotRepository.GetParkingLotsInRange(pageIndex);
        }

        public async Task<ParkingLot> GetParkingLotByIdAsync(string id)
        {
            return await _parkingLotRepository.GetParkingLotById(id);
        }

        internal Task<object?> UpdateParkingLot(ParkingLot parkingLot)
        {
            throw new NotImplementedException();
        }
    }
}

using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        private static int MIN_CAPACITY = 10;
        public ParkingLotService(IParkingLotRepository repository)
        {
            this._parkingLotRepository = repository;
        }

        private readonly IParkingLotRepository _parkingLotRepository;

        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < MIN_CAPACITY)
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
            if (await _parkingLotRepository.GetParkingLotById(id) != null)
            {
                return await _parkingLotRepository.GetParkingLotById(id);
            }
            else
            {
                throw new IDNotExistException();
            }           
        }

        public async Task<ParkingLot> UpdateParkingLotCapacity(ParkingLot parkingLot)
        {
            if(parkingLot.Capacity < MIN_CAPACITY)
            {
                throw new InvalidCapacityException();
            }
            if (await _parkingLotRepository.GetParkingLotById(parkingLot.Id) != null)
            {
                return await _parkingLotRepository.UpdateParkingLotCapacity(parkingLot);
            }
            else
            {
                throw new IDNotExistException();
            }
        }
    }
}

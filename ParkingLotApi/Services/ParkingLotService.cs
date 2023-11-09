using MongoDB.Bson;
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
            _parkingLotRepository = repository;
        }

        private readonly IParkingLotRepository _parkingLotRepository;

        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < MIN_CAPACITY)
            {
                throw new InvalidCapacityException();
            }
            var allParkingLots = await _parkingLotRepository.GetAllParkingLots();
            if (allParkingLots.Exists(x => x.Name == parkingLotDto.Name))
            {
                throw new NameAlreadyExistException();
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
            if (ObjectId.TryParse(id, out _))
            {
                if (await _parkingLotRepository.GetParkingLotById(id) != null)
                {
                    await _parkingLotRepository.DeleteParkingLotById(id);
                }
            }

            throw new IDNotExistException(id);
            
            
        }

        public async Task<List<ParkingLot>> GetParkingLotByPageAsync(int pageIndex)
        {
            if(pageIndex < 1)
            {
                throw new PageIndexException();
            }
            return await _parkingLotRepository.GetParkingLotsInRange(pageIndex);
        }

        public async Task<ParkingLot> GetParkingLotByIdAsync(string id)
        {
            if (ObjectId.TryParse(id, out _))
            {
                if (await _parkingLotRepository.GetParkingLotById(id) != null)
                {
                    return await _parkingLotRepository.GetParkingLotById(id);
                }
            }
            throw new IDNotExistException(id);
                      
        }

        public async Task<ParkingLot> UpdateParkingLotCapacity(string id, int capacity)
        {
            if(capacity < MIN_CAPACITY)
            {
                throw new InvalidCapacityException();
            }
            if (ObjectId.TryParse(id, out _))
            {
                if (await _parkingLotRepository.GetParkingLotById(id) != null)
                {
                    return await _parkingLotRepository.UpdateParkingLotCapacity(id, capacity);
                }
            }
            throw new IDNotExistException(id);
            
        }
    }
}

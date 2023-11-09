using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        private readonly IParingLotRepository _paringLotRepository;

        public ParkingLotService(IParingLotRepository paringLotRepository)
        {
            _paringLotRepository = paringLotRepository;
        }

        public async Task<ParkingLot> AddSync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }

            return await _paringLotRepository.CreateParkingLotAsync(parkingLotDto.ToEntity());
        }

        public async Task DeleteOneParkingLotAsync(string id)
        {
            await _paringLotRepository.DeleteOneParkingLotAsync(id);
        }

        public async Task<ParkingLot> GetOneParkingLotByIdAsync(string id)
        {
            return await _paringLotRepository.GetOneParkingLotByIdAsync(id);
        }

        public async Task<List<ParkingLot>> GetOnePageParkingLotsAsync(int pageIndex)
        {
            return  await _paringLotRepository.GetOnePageParkingLotsAsync(pageIndex);
        }

        public async Task<ActionResult<ParkingLot>> UpdateOneAsync(UpdateParkingLotDto updateParkingLotDto)
        {
            return await _paringLotRepository.UpdateOneAsync(updateParkingLotDto);
        }
    }
}

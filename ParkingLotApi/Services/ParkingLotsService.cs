using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
   
            return await parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
        }

        public async Task<ParkingLot?> GetById(string id)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                throw new InvalidObjectIdException();
            }
            var result = await parkingLotsRepository.GetById(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return result;
            }
        }

        public async Task DeleteById(string id)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                throw new InvalidObjectIdException();
            }
            var result = await parkingLotsRepository.GetById(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            else
            {
                await parkingLotsRepository.DeleteById(id);
            }
        }



    }
}

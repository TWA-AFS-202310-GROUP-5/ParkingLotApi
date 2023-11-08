using ParkingLotApi.Dtos;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        public ParkingLotService() { }

        public async Task<ParkingLotDto> AddSync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)
            {
                throw new ArgumentException();
            }

            return null;
        }
    }
}

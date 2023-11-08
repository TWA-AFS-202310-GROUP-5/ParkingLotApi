using ParkingLotApi.Models;

namespace ParkingLotApi.Dtos
{
    public class UpdateParkingLotDto
    {
        public string Id { get; set; }
        public int Capacity { get; set; }
    }
}

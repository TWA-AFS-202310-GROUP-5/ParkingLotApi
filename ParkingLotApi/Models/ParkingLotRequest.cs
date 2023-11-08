namespace ParkingLotApi.Models
{
    public class ParkingLotRequest
    {
        public required string Name { get; set; }
        public int Capacity { get; set; }
        public string? Location { get; set; }
    }
}

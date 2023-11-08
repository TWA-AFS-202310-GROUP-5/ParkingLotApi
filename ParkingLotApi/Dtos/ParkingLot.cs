namespace ParkingLotApi.Dtos
{
    public class ParkingLot
    {
        public required string id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public string? Location { get; set; }
    }
}

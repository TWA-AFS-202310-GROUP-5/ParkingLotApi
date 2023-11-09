namespace ParkingLotApi.Models
{
    public class ParkingLotRequest
    {
        public required string Name { get; set; }
        public int Capacity { get; set; }
        public string? Location { get; set; }

        public ParkingLot ToParkingLot()
        {
            return new ParkingLot
            {
                Name = Name,
                Capacity = Capacity,
                Location = Location
            };
        }
    }
}

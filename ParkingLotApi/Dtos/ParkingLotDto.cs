namespace ParkingLotApi.Dtos
{
    public class ParkingLotDto
    {
        public ParkingLotDto(string name, int capacity, string location)
        {
            Name = name;
            Capacity = capacity;
            Location = location;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}
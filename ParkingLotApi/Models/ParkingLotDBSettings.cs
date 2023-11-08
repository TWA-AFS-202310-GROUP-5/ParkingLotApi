namespace ParkingLotApi.Models
{
    public class ParkingLotDBSettings
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string CollectionName { get; set; }

    }
}

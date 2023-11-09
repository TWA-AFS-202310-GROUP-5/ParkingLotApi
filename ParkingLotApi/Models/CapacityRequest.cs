using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ParkingLotApi.Models
{
    public class CapacityRequest
    {
        public int Capacity { get; set; }
    }
}




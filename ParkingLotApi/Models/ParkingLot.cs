
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ParkingLotApi.Models
{
    public class ParkingLot
    {/*
        public ParkingLot(string name, int capacity, string location)
        {
            Name = name;
            Capacity = capacity;
            Location = location;
        }*/

        //public static string CollectionName { get; set; } = "ParkingLot";

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 

        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; } 
    }
}

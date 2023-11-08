using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLot> parkingLotCollection;

        public ParkingLotsRepository(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSettingsWithOptions)
        {
            ParkingLotDatabaseSettings parkingLotDatabaseSettings = parkingLotDatabaseSettingsWithOptions.Value;
            var mongoClient = new MongoClient(parkingLotDatabaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSettings.DatabaseName);
            parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.CollectionName);
        }

        public async Task<ParkingLot> CreateParkingLotAsync(ParkingLot parkingLot)
        {
            await parkingLotCollection.InsertOneAsync(parkingLot);
            return await GetParkingLotByNameAsync(parkingLot.Name);
        }

        public async Task DeleteParkingLotAsync(string id)
        {
            parkingLotCollection.DeleteOne(_=>_.id == id);
        }

        public async Task<ParkingLot> GetParkingLotByNameAsync(string name)
        {
            return await parkingLotCollection.Find(_ => _.Name == name).FirstOrDefaultAsync();
        }
    }
}

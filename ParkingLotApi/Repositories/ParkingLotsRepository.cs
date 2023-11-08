using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;
        public ParkingLotsRepository(IOptions<ParkingLotDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(databaseSettings.Value.CollectionName);
        }

        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotCollection.InsertOneAsync(parkingLot);
            return await _parkingLotCollection.Find(a => a.Name == parkingLot.Name).FirstAsync();
        }

        public async Task<ParkingLot> GetParkingLotById(string id)
        {
            return await _parkingLotCollection.Find(x => x.Id == id).FirstAsync();
        }

        public async Task DeleteById(string id)
        {
            await _parkingLotCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ParkingLot>> GetParkingLots(int pageIndex)
        {
           return _parkingLotCollection.Find(_ => true).ToList().Skip((pageIndex - 1) * 15).Take(15).ToList();
        }

        public async Task<ParkingLot> UpdateParkingLotById(string id, UpdateRequest request)
        {
            await _parkingLotCollection.UpdateOneAsync(Builders<ParkingLot>.Filter.Eq(p => p.Id, id),
                Builders<ParkingLot>.Update.Set(x => x.Capacity, request.Capacity));
            return await _parkingLotCollection.Find(x => x.Id == id).FirstAsync();
        }
    }
}

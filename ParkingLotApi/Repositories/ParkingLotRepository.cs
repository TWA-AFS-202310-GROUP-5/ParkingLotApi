using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;
using System.Diagnostics.Metrics;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;

        public ParkingLotRepository(IOptions<ParkingLotDBSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(options.Value.CollectionName);
        }

        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotCollection.InsertOneAsync(parkingLot);
            return await _parkingLotCollection.Find(x => x.Name == parkingLot.Name).FirstOrDefaultAsync();
        }

        public async Task DeleteParkingLotById(string id)
        {
            await _parkingLotCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ParkingLot>> GetParkingLotsInRange(int pageIndex)
        {
            var allParkingLots = await GetAllParkingLots();
            return allParkingLots.Skip((pageIndex - 1) * 15).Take(15).ToList();
        }

        public async Task<ParkingLot> GetParkingLotById(string id)
        {
            return await _parkingLotCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ParkingLot> UpdateParkingLotCapacity(string id, int capacity)
        {
            var filter = Builders<ParkingLot>.Filter.Where(x => x.Id == id);
            var update = Builders<ParkingLot>.Update.Set(e => e.Capacity, capacity);
            var options = new FindOneAndUpdateOptions<ParkingLot, ParkingLot>
            {
                IsUpsert = false,
                ReturnDocument = ReturnDocument.After
            };
            return await _parkingLotCollection.FindOneAndUpdateAsync(filter, update, options);
        }
        public async Task<List<ParkingLot>> GetAllParkingLots()
        {
            return await _parkingLotCollection.Find(_ => true).ToListAsync();
        }
    }
}

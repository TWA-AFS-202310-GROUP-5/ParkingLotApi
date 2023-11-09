using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;

        public ParkingLotsRepository(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSettings)
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSettings.Value.DatabaseName);
            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.Value.CollectionName);
        }

        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotCollection.InsertOneAsync(parkingLot);
            return await _parkingLotCollection.Find(a => a.Name== parkingLot.Name).FirstOrDefaultAsync(); 
        }

        public async Task<ParkingLot> GetById(string id)
        {
            return await _parkingLotCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ParkingLot?>> GetPage(int pageIndex)
        {
            int pageSize = 15;
            int skipCount = (pageIndex - 1) * pageSize;
            
            return await _parkingLotCollection.AsQueryable().Skip(skipCount).Take(pageSize).ToListAsync();
        }

        public async Task DeleteById(string id)
        {
            await _parkingLotCollection.DeleteOneAsync(doc => doc.Id == id);
        }

        public async Task<ParkingLot> UpdateCapacity(string id, CapacityRequest capacity)
        {
            var oldParkingLot = await _parkingLotCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            ParkingLot newParkingLot = new ParkingLot()
            {
                Id = oldParkingLot.Id,
                Capacity = capacity.Capacity,
                Name = oldParkingLot.Name,
                Location = oldParkingLot.Location,
            };
            await _parkingLotCollection.ReplaceOneAsync(x => x.Id == id, newParkingLot);
            return newParkingLot;
        }
    }
}

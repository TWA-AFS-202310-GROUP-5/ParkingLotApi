using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;
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

        public Task<List<ParkingLot>> GetParkingLotsInRange(int pageIndex)
        {
            throw new NotImplementedException();
        }

        public Task<ParkingLot> GetParkingLotById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ParkingLot> UpdateParkingLotById(string id)
        {
            throw new NotImplementedException();
        }
    }
}

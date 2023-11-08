﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public class ParingLotRepository : IParingLotRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotsCollection;

        public ParingLotRepository(IOptions<ParkingLotDatabaseSetting> parkLotSetting)
        {
            var mongoClient = new MongoClient(parkLotSetting.Value.MongDBUrl);
            var mongoDatabase = mongoClient.GetDatabase(parkLotSetting.Value.DatabaseName);
            _parkingLotsCollection = mongoDatabase.GetCollection<ParkingLot>(parkLotSetting.Value.CollectionName);
        }
        public async Task<ParkingLot> CreateParkingLotAsync(ParkingLot parkingLot)
        {
            await _parkingLotsCollection.InsertOneAsync(parkingLot);
            return await _parkingLotsCollection.Find(p => p.Name == parkingLot.Name).FirstAsync();
        }

        public async Task DeleteOneParkingLotAsync(string id)
        {
            _parkingLotsCollection.DeleteOneAsync(p => p.Id == id);
        }

        public async Task<ParkingLot> GetOneParkingLotById(string id)
        {
            return await _parkingLotsCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public List<ParkingLot> GetOnePageParkingLots(int pageIndex)
        {
            return _parkingLotsCollection.Find(_ => true).ToList().Skip((pageIndex - 1) * 15).Take(15).ToList();

        }
    }
}

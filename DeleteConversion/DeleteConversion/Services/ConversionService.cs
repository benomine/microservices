using MongoDB.Driver;
using DeleteConversion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DeleteConversion.Services
{
    public class ConversionService
    {
        private readonly IMongoCollection<Conversion> _conversions;

        public ConversionService(IConversionDatabaseSettings settings)
        {
            var mongoClient = new MongoClient(Startup.ConnectionString);
            //var database = mongoClient.GetDatabase("temperature");
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            //_conversions = database.GetCollection<Conversion>("appels");
            _conversions = database.GetCollection<Conversion>(settings.ConversionsCollectionName);
        }

        public async Task<List<Conversion>> GetConversionsAsync()
        {
            return await _conversions.Find(Builders<Conversion>.Filter.Empty).ToListAsync();
        }

        public async Task<Conversion> GetConversionAsync(string id)
        {
            return await _conversions.Find(conv => conv.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteConversionAsync(string id) {
            var result = await _conversions.DeleteOneAsync(conversion => conversion.Id == id);
            return await Task.FromResult(result.DeletedCount > 0 && result.IsAcknowledged);
        } 
    }
}

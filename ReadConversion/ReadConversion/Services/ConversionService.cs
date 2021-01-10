using MongoDB.Driver;
using ReadConversion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadConversion.Services
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
    }
}

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpdateConversion.Models;

namespace UpdateConversion.Services
{
    public class ConversionService
    {
        private readonly IMongoCollection<Conversion> _conversions;

        public ConversionService(IConversionDatabaseSettings settings)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
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

        public async Task<Conversion> UpdateConversionAsync(Conversion update) {
            return await _conversions.FindOneAndReplaceAsync(conversion => conversion.Id == update.Id, update);
        }
    }
}

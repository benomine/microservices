using CreateConversion.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateConversion.Services
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

        public Task InsertConversion(Conversion conversion)
        {
            Task task = _conversions.InsertOneAsync(conversion);
            return task;
        }
    }
}

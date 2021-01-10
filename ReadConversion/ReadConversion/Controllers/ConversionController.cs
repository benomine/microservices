using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using ReadConversion.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReadConversion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : Controller
    {
        private static IMongoCollection<Conversion> GetCollection()
        {
            MongoClient mongoClient = new MongoClient(Startup.ConnectionString);
            var database = mongoClient.GetDatabase("temperature");
            var collection = database.GetCollection<Conversion>("appels");
            return collection;
        }

        [HttpGet]
        public IEnumerable<Conversion> GetAll()
        {
            IMongoCollection<Conversion> collection = GetCollection();

            var retour = collection.Find(new BsonDocument()).ToList();
            return retour;
        }
    }
}

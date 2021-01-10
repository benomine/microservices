using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using UpdateConversion.Models;

namespace UpdateConversion.Controllers
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

        [HttpPut]
        public IActionResult UpdateConversion([FromBody] Conversion update)
        {
            IMongoCollection<Conversion> collection = GetCollection();

            var conversion = collection.Find<Conversion>(update.Id);

            if (conversion == null)
            {
                return NotFound(update.Id);
            }

            collection.ReplaceOne(conversion => conversion.Id == update.Id, update);

            return Accepted("Update ok");
        }
    }
}

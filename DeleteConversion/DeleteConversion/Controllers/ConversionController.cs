using DeleteConversion.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DeleteConversion.Controllers
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

        [HttpDelete]
        public IActionResult DeleteConversion([FromBody] Conversion toBeDeleted)
        {
            IMongoCollection<Conversion> collection = GetCollection();

            var conversion = collection.Find(toBeDeleted.Id);

            if(conversion == null)
            {
                return NotFound(toBeDeleted.Id);
            }

            collection.FindOneAndDelete(conv => conv.Id == toBeDeleted.Id);

            return Accepted("Delete done");
        }

    }
}

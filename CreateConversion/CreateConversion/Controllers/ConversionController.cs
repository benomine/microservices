using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using CreateConversion.Models;

namespace CreateConversion.Controllers
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

        [HttpPost]
        public IActionResult InsertConversion([FromBody] Conversion conversion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            IMongoCollection<Conversion> collection = GetCollection();
            collection.InsertOne(conversion);
            return Accepted("Ok");
        }
    }
}
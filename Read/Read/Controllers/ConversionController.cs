using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using ReadConversion.Models;
using ReadConversion.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadConversion.Controllers
{
    [ApiController]
    [Route("api/[controller]/read")]
    public class ConversionController : Controller
    {

        private readonly ConversionService _conversionService;

        public ConversionController(ConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Conversion>>> GetAllAsync()
        {
            return await _conversionService.GetConversionsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Conversion>> GetAsync(string id)
        {
            return await _conversionService.GetConversionAsync(id);
        }
    }
}

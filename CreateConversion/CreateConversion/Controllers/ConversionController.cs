using Microsoft.AspNetCore.Mvc;
using CreateConversion.Models;
using CreateConversion.Services;
using System.Threading.Tasks;

namespace CreateConversion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : Controller
    {
        private readonly ConversionService _conversionService;

        public ConversionController(ConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertConversionAsync([FromBody] Conversion conversion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            await _conversionService.InsertConversion(conversion);

            return Accepted("Ok");
        }
    }
}
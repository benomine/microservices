using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UpdateConversion.Models;
using UpdateConversion.Services;

namespace UpdateConversion.Controllers
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

        [HttpPut]
        public async Task<IActionResult> UpdateConversionAsync([FromBody] Conversion update)
        {
            var conversion = _conversionService.GetConversionAsync(update.Id);

            if (conversion == null)
            {
                return NotFound(update.Id);
            }

            await _conversionService.UpdateConversionAsync(update);

            return Accepted("Update ok");
        }
    }
}

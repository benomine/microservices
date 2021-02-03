using DeleteConversion.Models;
using DeleteConversion.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DeleteConversion.Controllers
{
    [ApiController]
    [Route("api/[controller]/delete")]
    public class ConversionController : Controller
    {
        private readonly ConversionService _conversionService;

        public ConversionController(ConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteConversionAsync([FromBody] string id)
        {
            var delete = await _conversionService.DeleteConversionAsync(id);

            if (!delete)
            {
                NotFound(id);
            }

            return Accepted("Delete done");
        }

    }
}

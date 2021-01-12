using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CTService.Models;
using CTService.Services;

namespace CTService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ConversionTemperatureController : Controller
    {

        private readonly ConversionService _service;

        public ConversionTemperatureController(ConversionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> ConversionAsync([FromBody] Conversion conversion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var result = conversion.Sens == 0 ? Calculs.Calculs.ConvertFToC(conversion.Valeur) : Calculs.Calculs.ConvertCToF(conversion.Valeur);

            await _service.SendCreate(conversion);

            return Accepted(result);
        }
    }
}

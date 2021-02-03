using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Conversion.Models;
using Conversion.Services;

namespace Conversion.Controllers
{

    [ApiController]
    [Route("api/[controller]/temperature")]
    public class ConversionController : Controller
    {

        private readonly ConversionService _service;

        public ConversionController(ConversionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> ConversionAsync([FromBody] Models.Conversion conversion)
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

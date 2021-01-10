using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CTService.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace CTService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionTemperatureController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> ConversionAsync([FromBody] Conversion conversion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var result = conversion.Sens == 0 ? Calculs.Calculs.ConvertFToC(conversion.Valeur) : Calculs.Calculs.ConvertCToF(conversion.Valeur);

            await SendCreate(conversion);

            return Accepted(result);
        }

        private static async Task<HttpResponseMessage> SendCreate(Conversion conversion)
        {
            using var client = new HttpClient();

            var uri = new Uri(Startup.ConnectionString+"/api/conversion");
            var json = JsonConvert.SerializeObject(conversion);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PostAsync(uri, data);
        }
    }
}

using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Conversion.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Conversion.Services
{
    public class ConversionService
    {
        private readonly IConversionDatabaseSettings _settings;
        public ConversionService(IConversionDatabaseSettings settings)
        {
            _settings = settings;
        }
        public async Task SendCreate(Models.Conversion conversion)
        {
            using var client = new HttpClient(new HttpClientHandler {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
            });

            var uri = new Uri(_settings.ConnectionString);
            var json = JsonConvert.SerializeObject(conversion);

            var request = new HttpRequestMessage {
                RequestUri = uri,
                Method = HttpMethod.Post,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            await client.SendAsync(request);
        }
    }
}
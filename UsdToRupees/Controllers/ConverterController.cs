using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace UsdToRupees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public ConverterController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("convert")]
        public async Task<IActionResult> ConvertUsdToInr([FromQuery] decimal amount)
        {
            if (amount <= 0)
            {
                return BadRequest("Amount must be greater than zero.");
            }
            var response = await _httpClient.GetStringAsync("https://api.exchangerate-api.com/v4/latest/USD");
            var data = JObject.Parse(response);
            var exchangeRate = data["rates"]["INR"].Value<decimal>();
            var convertedAmount =  amount * exchangeRate;

            return Ok(new { OriginalAmount = amount, ConvertedAmount = convertedAmount });
        }
    }
}

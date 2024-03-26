using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HodlSolution.Controllers
{
    public class OvexMarketController : Controller
    {
        private readonly HttpClient _client;

        public OvexMarketController()
        {
            _client = new HttpClient();
        }
        [Route("api/OvexCurrencies")]
        [HttpGet]
        public async Task<IActionResult> GetOvexCurrencies()
        {
            try
            {
                var response = await _client.GetAsync("https://www.ovex.io/api/v2/currencies");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving data from OVEX: {ex.Message}");
            }
            finally
            {
                _client.Dispose(); 
            }
        }
        [Route("api/OvexMarkets")]
        [HttpGet]
        public async Task<IActionResult> GetOvexMarkets()
        {
            try
            {
                var response = await _client.GetAsync("https://www.ovex.io/api/v2/markets");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving data from OVEX: {ex.Message}");
            }
            finally
            {
                _client.Dispose();
            }
        }

    }
}

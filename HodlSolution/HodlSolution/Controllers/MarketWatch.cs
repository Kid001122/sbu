using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HodlSolution.Controllers
{
    public class MarketWatch : Controller
    {
        private readonly HttpClient _client;

        public MarketWatch()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "27173a6f-b74a-4300-b5d6-314699b6164c");
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiJ9.eyJpYXQiOjE3MTAxNDM5MjEsImV4cCI6MTc0MTU5MzUyMSwic3ViIjoic2Vzc2lvbiIsImlzcyI6ImJhcm9uZyIsImF1ZCI6InBlYXRpbyIsImp0aSI6IjNEMUQ0MkVDNjhGQTZBMzkzMTkwNUExQSIsInVpZCI6IklENkYyMjMyMDI3OCIsImVtYWlsIjoiaW5mb0Bob2Rsb3RjLmlvIiwicm9sZSI6Im1lbWJlciIsImxldmVsIjozLCJzdGF0ZSI6ImFjdGl2ZSIsIm90cF9lbmFibGVkIjp0cnVlLCJhcGlfa2lkIjoiNTU4OTVjMjktOGY2Ny00N2Q4LTgwYWYtYmQ4ZjBlY2IzMmJjIn0.BSga2ED0pXy6vnI3USK4LuciL0QCRSUw9gmXeM1pc-jTeUhyJmbQEq7fxbmK9ioEF1QuAZ_af-93JZxNYCFLPXZ8JAVU4fYm9sd44CyR4zHA2-D5z2Zyw7b5RSpxbsAyvqv4QyJ_1Cokuv0ah68dtwn-xYUZBQPWpA1tT5orWihuZVSyo1CMHVvjUgUUcLvHSRUaw_f3TmAO-xTHTrtaDor2y0fqnJN4DJ1tAHMJYhH4qAdFA7yRNsZtwmPjGWJz3yEyDabtLOAKuNKTsKu9IEH2H4BHQBmBwSBlvg3bRf8dzZXE8zqfhxKPzaRRIvrhN2PrPpWTBVFBepqybUNttA");
        }
        [Route("api/MarketWatch")]
        [HttpGet]
        public async Task<IActionResult> GetMarketData()
        {
            try
            {
                var response = await _client.GetAsync("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving data from CoinMarketCap: {ex.Message}");
            }
            finally
            {
                _client.Dispose(); // Dispose HttpClient to release resources
            }
        }
        [Route("api/MarketWatchCap")]
        [HttpGet]
        public async Task<IActionResult> GetMarketDataCap()
        {
            try
            {
                var response = await _client.GetAsync("");
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error getting the data from CoinMarketCap {ex.Message}");
            }
            finally { _client.Dispose(); }
        }
    }
}

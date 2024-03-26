using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using System.Text;

namespace HodlSolution.Controllers
{
    public class QuoteController : Controller
    {
        private readonly HttpClient _client;
        public QuoteController()
        {
            _client = new HttpClient();
             _client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiJ9.eyJpYXQiOjE3MTEzNTY4NTUsImV4cCI6MTc0MjgwNjQ1NSwic3ViIjoic2Vzc2lvbiIsImlzcyI6ImJhcm9uZyIsImF1ZCI6InBlYXRpbyIsImp0aSI6IjMyMjU0NTQ0QTExNkUyMzJBQjAxREIwMSIsInVpZCI6IklEMzMxQzE4N0QwOSIsImVtYWlsIjoiYnVidTEzZ3VAZ21haWwuY29tIiwicm9sZSI6Im1lbWJlciIsImxldmVsIjoxLCJzdGF0ZSI6ImFjdGl2ZSIsIm90cF9lbmFibGVkIjp0cnVlLCJhcGlfa2lkIjoiZTRiODNjMTAtMDFlMi00N2E1LThiYmYtZDE1NTNlNWIyM2NiIn0.XKFIEOAi_CUBxTSTTYgTXVHrEPZN9pb1MSAPFUczK5M0mPaHnu6FsQp7XvT4lzXovLXtTYL5_JcptMqkh_CidBiiT9pzkMB5jyJPbHOjPCOw4ukzi_5nuiMeOXd1LaI-86_omN9jFIBOJXGu0fNrqrpM9YGcWFDqeVxEdXk0D2TUIa9a1H_faOX94htvWtxKV6fSREaJLh3w9p9tpRY2y5v5rbAF2KGKfg211JKpKagXhogFuXvfdl3Fzmbv44WIXRL_jcYtsce_EJD3GF2JTqgF7K-YA32yZPIW8DYk1FE-UQalVgKkUeZY7sqAA7yDcbfhSjTHAZX4ZOyr6hpQjg");
        }
        [HttpGet]
        [Route("api/GetDeposits")]
        public async Task<IActionResult> GetDeposit()
        {
            try
            {
                var url = $"https://api.review.ovex.io/api/v2/broker/deposits";
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving Deposit from OVEX: {ex.Message}");
            }
            finally
            {
                _client.Dispose();
            }
        }

        [HttpGet]
        [Route("api/GetDepositAddress")]
        public async Task<IActionResult> GetDepositAddress()
        {
            try
            {
                var url = $"https://api.review.ovex.io/api/v2/broker/deposit_addresses";
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving Deposit Address from OVEX: {ex.Message}");
            }
            finally
            {
                _client.Dispose();
            }
        }
        [HttpGet]
        [Route("api/GetClients")]
        public async Task<IActionResult> Getclients()
        {
            try
            {
                var url = $"https://api.review.ovex.io/api/v2/broker/clients";
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving Clients from OVEX: {ex.Message}");
            }
            finally
            {
                _client.Dispose();
            }
        }

        [HttpGet]
        [Route("api/GetQuotefrom")]
        public async Task<IActionResult> GetQuotefrom(string market, string side, decimal from_amount,string sn, string prefunded)
        {
            try
            {
                var url = $"https://api.review.ovex.io/api/v2/broker/rfq/get_quote?market={market}&from_amount={from_amount}&side={side}&sn={sn}&prefunded={prefunded}";
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving quote from OVEX: {ex.Message}");
            }
            finally
            {
                _client.Dispose();
            }
        }
        [HttpGet]
        [Route("api/GetQuoteTo")]
        public async Task<IActionResult> GetQuoteto(string market, string side, decimal to_amount, string sn, string prefunded)
        {
            try
            {
                var url = $"https://api.review.ovex.io/api/v2/broker/rfq/get_quote?market={market}&to_amount={to_amount}&side={side}&sn={sn}&prefunded={prefunded}";
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error retrieving quote from OVEX: {ex.Message}");
            }
            finally
            {
                _client.Dispose();
            }
        }
        [HttpPost]
        [Route("api/AcceptQuote")]
        public async Task<IActionResult> AcceptQuote(string quoteToken)
        {
            try
            {
                var url = "https://api.review.ovex.io/rfq/accept_quote";
                var requestBody = new StringContent(
                    "{\"quote_token\": \"" + quoteToken + "\"}",
                    Encoding.UTF8,
                    "application/json"
                );
                var response = await _client.PostAsync(url, requestBody);
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error accepting quote from OVEX: {ex.Message}");
            }
            finally
            {
                _client.Dispose();
            }
        }


    }
}

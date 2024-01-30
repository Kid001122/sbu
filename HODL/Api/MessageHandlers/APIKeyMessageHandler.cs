using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace API.MessageHandlers
{
    public class APIKeyMessageHandler : DelegatingHandler
    {
        private const string APIKeyToCheck = "t3iKRnspNMAyNmEoJg6t";
        public static string APIImage = "";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {
            bool validKey = false;
            IEnumerable<string> requestHeaders;
            try
            {
                var checkAPiKeyExists = httpRequestMessage.Headers.TryGetValues("APIKey", out requestHeaders);
                string s = requestHeaders.FirstOrDefault().ToString().Replace("'", "");
                s = s.Replace("%27", "");
                if (checkAPiKeyExists)
                {
                    if (s.Equals(APIKeyToCheck))
                    {
                        validKey = true;
                    }
                }

                string text1 = s;
            }
            catch (Exception)
            {
            }

            if (!validKey)
            {
                return httpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key");
            }

            var response = await base.SendAsync(httpRequestMessage, cancellationToken);
            return response;
        }
    }
}
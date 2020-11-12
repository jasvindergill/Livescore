using Android;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Livescore.Models.BaseModel
{
    public class Base
    {
        private string url = "https://apiv2.apifootball.com/?action=";
        protected string apiKey = "&APIkey=f4364a4fc7237e8f3c2e3bdadfce4ff763b8dfc6cc39d07dcbb2d398f2d4e2c4";

        public async Task<APIResponse> GetResponse(string actionUrl, string auth = null)
        {
            url += actionUrl + apiKey;

            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(auth))
                    client.DefaultRequestHeaders.Add("Authorization", auth);

                var request = await client.GetAsync(url);
                if (request.IsSuccessStatusCode)
                {
                    return new APIResponse { Response = await request.Content.ReadAsStringAsync() };
                }
                else
                    return new APIResponse { ErrorMessage = request.ReasonPhrase };
            }

        }
    }

    public class APIResponse
    {
        public bool Successful => ErrorMessage == null;
        public string ErrorMessage { get; set; }
        public string Response { get; set; }
    }
}

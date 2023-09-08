using Newtonsoft.Json;
using Imgur.API.Models;
using RestSharp;

namespace Promocoes.Application.Input.Services.Imgur.OAuth2
{
    public class ImgurAuthorization
    {

        public static string OAuth2()
        {
            string clientId = "5859e2e8632165e";
            string clientSecret = "dd56be9ba0e42cf82e19e16ae76a2f712588a40a";

            var token = new OAuth2Token
            {
                AccessToken = "ea56a44acc24b9f47a312660013eb07322c1bce9",
                RefreshToken = "fd6a91931d77ba270bdabe12cea55cf406952bef",
                AccountId = 171995865,
                AccountUsername = "YOUR_ACCOUNT_PASSWORD",
                ExpiresIn = 315360000,
                TokenType = "bearer"
            };

            var options = new RestClientOptions("https://api.imgur.com")
            {
            MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/oauth2/token", Method.Post)
            {
                AlwaysMultipartFormData = true
            };
            request.AddParameter("refresh_token", token.RefreshToken);
            request.AddParameter("client_id", clientId);
            request.AddParameter("client_secret", clientSecret);
            request.AddParameter("grant_type", "refresh_token");

            RestResponse response = client.Execute(request);

            TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(response.Content);
            string formattedJson = JsonConvert.SerializeObject(tokenResponse, Formatting.Indented);

            return formattedJson;
        }
        public class TokenResponse
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }
            public string token_type { get; set; }
            public string refresh_token { get; set; }
            public int account_id { get; set; }
            public string account_username { get; set; }
        }
    }
}
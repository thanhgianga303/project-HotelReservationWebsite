using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient(); // khởi tạo client 

            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");// lấy json từ IdentityAPI

            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }
            //Nhận
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint, // lấy "token_endpoint":"http://localhost:5000/connect/token"
                //HTTPS phải được sử dụng cho điểm cuối khám phá và tất cả các điểm cuối giao thức
                ClientId = "admin",
                ClientSecret = "secret",
                Scope = "hotel"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            //1 token gồm access_token, token_type, expires_in, scope
            // set token vào client 
            client.SetBearerToken(tokenResponse.AccessToken);
            //Access token là một chuỗi được sinh ngẫu nhiên giúp xác định người dùng,
            // ứng dụng hoặc trang và ta có thể dùng mã đó để thực hiện lệnh gọi Graph API

            //Hầu như các câu lệnh gọi đến Graph API 
            //đều cần đến access token nên nó rất quan trọng đối với việc truy vấn thông tin từ Graph API

            //Access token khi decoded ra gồm : "iss": "http://localhost:5000",
            //"aud": "hotel", nó so sánh với bearer khi khởi tạo tao Hotel..API

            //Gọi tới api
            var response = await client.GetAsync("http://localhost:5001/api/account");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}

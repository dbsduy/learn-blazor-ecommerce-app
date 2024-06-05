using ECommerceApp.Interfaces;
using System.Net.Http.Json;

namespace ECommerceApp.Services
{
    public class AuthApi : IAuthApi
    {

        private readonly HttpClient _httpClient;

        public AuthApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IToken> Login(IAuth body)
        {
            var result = await _httpClient.PostAsJsonAsync("/auth/login", body);
            return await result.Content.ReadFromJsonAsync<IToken>();
        }

    }
}

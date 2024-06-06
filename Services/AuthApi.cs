using Blazored.LocalStorage;
using ECommerceApp.Interfaces;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ECommerceApp.Services
{
    public class AuthApi : IAuthApi
    {

        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jSRuntime;
        private readonly ILocalStorageService _localStorage;

        public AuthApi(HttpClient httpClient, IJSRuntime jSRuntime, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _jSRuntime = jSRuntime;
            _localStorage = localStorage;
        }


        public async Task<IToken> Login(IAuth body)
        {
            var res = await _httpClient.PostAsJsonAsync("/auth/login", body);
            var resultJson = await res.Content.ReadFromJsonAsync<IToken>();

            var token = resultJson.Token.Trim('"');

            await _localStorage.SetItemAsync("authToken", token);
            await _localStorage.SetItemAsync("username", token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return resultJson;
        }


        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("username");
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}

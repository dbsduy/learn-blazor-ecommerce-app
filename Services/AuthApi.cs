using Blazored.LocalStorage;
using ECommerceApp.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
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
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthApi(HttpClient httpClient, IJSRuntime jSRuntime, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _jSRuntime = jSRuntime;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }


        public async Task<IToken> Login(IAuth body)
        {
            var res = await _httpClient.PostAsJsonAsync("/auth/login", body);
            if (res.IsSuccessStatusCode)
            {
                var resultJson = await res.Content.ReadFromJsonAsync<IToken>();

                var token = resultJson.Token.Trim('"');

                await _localStorage.SetItemAsync("authToken", token);
                await _localStorage.SetItemAsync("username", token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(body.Username);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return resultJson;

            }
            else
            {
                await _jSRuntime.InvokeVoidAsync("alert", "Username or password is incorrect!");
                return new IToken();
            }
        }


        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("username");
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}

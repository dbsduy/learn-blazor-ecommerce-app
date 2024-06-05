using ECommerceApp.Data;
using System.Net.Http.Json;

namespace ECommerceApp.Services
{
    public class ProductApi : IProductApi
    {
        private readonly HttpClient _httpClient;

        public ProductApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IProduct> GetSingleProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<IProduct>($"/products/{id}");
        }

        public async Task<IEnumerable<IProduct>> GetAllProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<IProduct>>("/products");
        }
    }
}

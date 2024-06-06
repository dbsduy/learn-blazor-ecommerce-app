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

        //public async Task<IEnumerable<IProduct>> GetAllProducts(string? categoryType = null, string? sortType = null)
        //{

        //    if (!string.IsNullOrEmpty(categoryType))
        //    {
        //        return await _httpClient.GetFromJsonAsync<List<IProduct>>($"/products/category/{categoryType}");
        //    }

        //    return await _httpClient.GetFromJsonAsync<List<IProduct>>("/products");
        //}

        public async Task<IEnumerable<IProduct>> GetAllProducts(string? categoryType = null, string? sortType = null)
        {
            List<IProduct> products;

            if (!string.IsNullOrEmpty(categoryType))
            {
                products = await _httpClient.GetFromJsonAsync<List<IProduct>>($"/products/category/{categoryType}");
            }
            else
            {
                products = await _httpClient.GetFromJsonAsync<List<IProduct>>("/products");
            }

            if (!string.IsNullOrEmpty(sortType))
            {
                products = sortType switch
                {
                    "asc" => products.OrderBy(p => p.Price).ToList(),
                    "desc" => products.OrderByDescending(p => p.Price).ToList(),
                    _ => products
                };
            }

            return products;
        }


        public async Task<IEnumerable<ICategory>> GetAllCategories()
        {
            // Define your data list
            var data = new List<ICategory>
            {
                new ICategory { Name = "all", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFcfmuYfHnpMhSp1ZQRvjtdVf-ASwQrMpIww&s" },
                new ICategory { Name = "electronics", Image = "https://st2.depositphotos.com/3591429/10464/i/450/depositphotos_104649098-stock-photo-workplace-with-computer-in-office.jpg" },
                new ICategory { Name = "jewelery", Image = "https://www.josalukkasonline.com/Media/CMS/jos-alukkas-wedding-20231208145835676216.webp" },
                new ICategory {Name = "men's clothing", Image = "https://media.istockphoto.com/id/887360960/photo/mens-suits-on-hangers-in-different-colors.jpg?s=612x612&w=0&k=20&c=RR19yJjRuR-CBWj9u1sQkFgtdYJ07KEkM678R0mtuZY="},
                new ICategory {Name = "women's clothing", Image = "https://media.istockphoto.com/id/916092484/photo/women-clothes-hanging-on-hangers-clothing-rails-fashion-design.jpg?s=612x612&w=0&k=20&c=fUpcbOITkQqitglZfgJkWO3py-jsbuhc8eZfb4sdrfE="}
            };

            return data;
        }

    }
}



using Blazored.LocalStorage;
using ECommerceApp.Data;
using ECommerceApp.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

namespace ECommerceApp.Services
{
    public class CartApi : ICartApi
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public CartApi(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<IEnumerable<IProductInCart>> GetCartList()
        {
            var localCartList = await _localStorage.GetItemAsync<IEnumerable<IProductInCart>>("cart");
            return localCartList ?? new List<IProductInCart>();
        }

        public async Task AddToCart(IProductInCart product)
        {
            var cartList = (await GetCartList()).ToList();
            var existingProduct = cartList.FirstOrDefault(p => p.ProductId == product.ProductId);

            if (existingProduct != null)
            {

                existingProduct.Quantity += product.Quantity;
            }
            else
            {

                cartList.Add(product);
            }
            await _localStorage.SetItemAsync("cart", cartList);
        }


        public async Task DeleteFromCart(int productId)
        {
            var cartList = (await GetCartList()).ToList();
            var productToRemove = cartList.FirstOrDefault(p => p.ProductId == productId);

            if (productToRemove != null)
            {
                cartList.Remove(productToRemove);
                await _localStorage.SetItemAsync("cart", cartList);
            }
        }

        public async Task UpdateQuantity(int productId, bool isIncrease)
        {
            var cartList = (await GetCartList()).ToList();
            var productToUpdate = cartList.FirstOrDefault(p => p.ProductId == productId);

            if (productToUpdate != null)
            {
                if (isIncrease)
                {
                    productToUpdate.Quantity++;
                }
                else
                {
                    if (productToUpdate.Quantity > 0)
                    {
                        productToUpdate.Quantity--;
                    }
                    else
                    {
                        // Handle case where quantity is already 0
                        // Optionally, you can remove the product from the cart
                    }
                }
                await _localStorage.SetItemAsync("cart", cartList);
            }
        }

    }


}


using ECommerceApp.Interfaces;

namespace ECommerceApp.Services
{
    public interface ICartApi
    {
        public Task<IEnumerable<IProductInCart>> GetCartList();

        public Task AddToCart(IProductInCart product);

        public Task DeleteFromCart(int productId);

        public Task UpdateQuantity(int productId, bool isIncrease);
    }
}

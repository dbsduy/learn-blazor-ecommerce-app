using ECommerceApp.Data;

namespace ECommerceApp.Services
{
    public interface IProductApi
    {
        //** Get one product
        Task<IProduct> GetSingleProduct(int id);

        //** Get all products
        Task<IEnumerable<IProduct>> GetAllProducts();

    }
}

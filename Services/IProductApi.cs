using ECommerceApp.Data;

namespace ECommerceApp.Services
{
    public interface IProductApi
    {
        //** Get one product
        Task<IProduct> GetSingleProduct(int id);

        //** Get all products
        Task<IEnumerable<IProduct>> GetAllProducts(string? categoryType = null, string? sortType = null);


        Task<IEnumerable<ICategory>> GetAllCategories();

        Task<IEnumerable<IProduct>> GetProductWithLimit(int limit);
    }
}

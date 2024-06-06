using ECommerceApp.Interfaces;

namespace ECommerceApp.Services
{
    public interface IAuthApi
    {
        Task<IToken> Login(IAuth body);

        Task Logout();
    }
}

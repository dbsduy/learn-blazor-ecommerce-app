using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Interfaces
{
    public class IAuth
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }

    public class IToken
    {
        public string Token { get; set; }
    }
}

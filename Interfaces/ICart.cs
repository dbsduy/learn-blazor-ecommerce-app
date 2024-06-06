namespace ECommerceApp.Interfaces
{
    public class IProductInCart
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }
    }

}

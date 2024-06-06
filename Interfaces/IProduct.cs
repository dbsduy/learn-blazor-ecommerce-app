﻿namespace ECommerceApp.Data
{
    public class IProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public Rating Rating { get; set; }
    }


    public class Rating
    {
        public double Rate { get; set; }
        public int Count { get; set; }
    }

    public class ICategory
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}

﻿namespace _01_LampshadeQuery.Contracts.Product
{
    public class ProductColorQueryModel
    {
        public long ColorId { get; set; }
        public string ColorName { get; set; }
        public double Price { get; set; }
        public double PriceWithDiscount { get; set; }
    }
}
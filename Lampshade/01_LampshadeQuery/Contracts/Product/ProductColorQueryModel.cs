namespace _01_LampshadeQuery.Contracts.Product
{
    public class ProductColorQueryModel
    {
        public long ColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorPName { get; set; }
        public string Price { get; set; }
        public double PriceWithDiscount { get; set; }
        public long CurrentCount { get; set; }
    }
}
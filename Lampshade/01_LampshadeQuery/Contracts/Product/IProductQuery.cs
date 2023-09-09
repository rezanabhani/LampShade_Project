using System.Collections.Generic;


namespace _01_LampshadeQuery.Contracts.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetProductDetails(string slug);
        List<ProductQueryModel> GetLatestArrivals();
        List<ProductQueryModel> Search(string value);
        string GetUnitPrice(long ColorId,long ProductId);
        string GetUnitPriceWithDisCount(long ColorId, long ProductId);
    }
}

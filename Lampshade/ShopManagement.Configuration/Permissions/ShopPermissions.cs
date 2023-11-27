namespace ShopManagement.Configuration.Permissions
{
    public static class ShopPermissions
    {

        //ShowShopManagement
        public const int ShowShopManagement = 8;

        // Product
        public const int ShowProductManagement = 9;
        public const int ListProducts = 10;
        public const int SearchProducts = 11;
        public const int CreateProduct = 12;
        public const int EditProduct = 13;

        // ProductCategory 
        public const int ShowProductCategoryManagement = 19;
        public const int ListProductCategories = 20;
        public const int SearchProductCategories = 21;
        public const int CreateProductCategory = 22;
        public const int EditProductCategory = 23;


        // ProductPicture
        public const int ShowProductPictureManagement = 24;
        public const int ListProductPictures = 25;
        public const int SearchProductPictures = 26;
        public const int CreateProductPicture = 27;
        public const int EditProductPicture = 28;
        public const int RemoveProductPicture = 29;
        public const int RestoreProductPicture = 30;

        // CategoryType
        public const int ShowCategoryTypeManagement = 31;
        public const int ListCategoryTypes = 32;
        public const int CreateCategoryType = 33;
        public const int EditCategoryType = 34;

        //Slides
        public const int ShowSlideManagement = 35;
        public const int ListSlides = 36;
        public const int CreateSlide = 37;
        public const int EditSlide = 38;
        public const int RemoveSlide = 39;
        public const int RestoreSlide = 40;

        // Order
        public const int ShowOrderManagement = 41;
        public const int ListOrders = 42;
        public const int SearchOrders = 43;
        public const int ConfirmOrder = 44;
        public const int CancelOrder = 45;
        public const int OrderItems = 46;

    }
}

using System.Collections.Generic;
using _0_Framework.Application;
using InventoryManagement.Application.Contract.ProductColor;
using InventoryManagement.Domain.ProductColorAgg;

namespace InventoryManagement.Application
{
    public class ProductColorApplication : IProductColorApplication
    {
        private readonly IProductColorRepository _productRepository;

        public ProductColorApplication(IProductColorRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateColor command)
        {
            var operationResult = new OperationResult();

            var productColor = new ProductColor(command.Color);
            _productRepository.Create(productColor);
            _productRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Edit(EditColor command)
        {
            var operationResult = new OperationResult();
            var productColor = _productRepository.Get(command.Id);
            productColor.Edit(command.Color);
            _productRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public EditColor GetDetails(long id)
        {
           return _productRepository.GetDetails(id);
        }

        public List<ProductColorViewModel> GetList()
        {
            return _productRepository.GetList();
        }

        public List<ProductColorViewModel> GetListWithProduct()
        {
            return _productRepository.GetList();
        }
    }
}

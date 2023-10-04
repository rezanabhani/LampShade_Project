using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.CategoryType;
using ShopManagement.Domain.CategoryTypeAgg;

namespace ShopManagement.Application
{
    public class CategoryTypeApplication : ICategoryTypeApplication
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;

        public CategoryTypeApplication(ICategoryTypeRepository categoryTypeRepository)
        {
            _categoryTypeRepository = categoryTypeRepository;
        }

        public OperationResult Create(CreateCategoryType command)
        {
           var operation = new OperationResult();
           if (_categoryTypeRepository.Exists(x => x.Name == command.Name))
               return operation.Failed(ApplicationMessage.DuplicatedRecord);

           var categoryType = new CategoryType(command.Name);
           _categoryTypeRepository.Create(categoryType);
           _categoryTypeRepository.SaveChanges();
           return operation.Succedded();
        }

        public OperationResult Edit(EditCategoryType command)
        {
            var operation = new OperationResult();
            var categoryType = _categoryTypeRepository.Get(command.Id);
            if (categoryType == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_categoryTypeRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            categoryType.Edit(command.Name);
            _categoryTypeRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditCategoryType GetDetails(long id)
        {
           return _categoryTypeRepository.GetDetails(id);
        }

        public List<CategoryTypeViewModel> GetCategoryTypes()
        {
            return _categoryTypeRepository.GetCategoryTypes();
        }

        public List<CategoryTypeViewModel> GetCategories()
        {
            return _categoryTypeRepository.List();
        }
    }
}

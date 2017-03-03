namespace MvcApp.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BindingModels;
    using Data.Common.Repository;
    using Data.Models;
    using ViewModels;

    public class CategoriesServices
    {
        public bool IsNewCategoryValid(NewCategoryBindingModel bind)
        {
            return string.IsNullOrEmpty(bind.Name);
        }

        public void AddNewCategory(NewCategoryBindingModel bind, IDeletableEntityRepository<Category> categories)
        {
            Category category = new Category()
            {
                Name = bind.Name
            };

            //todo Mapper.Map<NewCategoryBindingModel, Category>(bind);
            categories.Add(category);
            categories.SaveChanges();
        }

        public AllViewModel GetAllViewModel(User user,
            IDeletableEntityRepository<Category> categories)
        {
            AllViewModel model = new AllViewModel();

            IEnumerable<CategoryViewModel> allCategories = categories.All()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    CategoryName = c.Name
                });

            model.Categories = allCategories;

            return model;
        }
    }
}
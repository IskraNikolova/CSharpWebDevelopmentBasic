namespace MvcApp.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Common.Repository;
    using Data.Models;
    using ViewModels;

    public class CategoriesServices
    {
        public AllViewModel GetAllViewModel(User user,
            IDeletableEntityRepository<Category> categories)
        {
            AllViewModel model = new AllViewModel();
            SignedViewModel signedViewModel = new SignedViewModel()
            {
                Username = user.Username
            };

            IEnumerable<CategoryViewModel> allCategories = categories.All()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    CategoryName = c.Name
                });

            model.SignedModel = signedViewModel;
            model.Categories = allCategories;

            return model;
        }
    }
}
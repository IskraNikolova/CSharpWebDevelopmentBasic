namespace MvcApp.Web.BindingModels
{
    using Data.Models;
    using Infrastucture.Mapping;

    public class NewCategoryBindingModel : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}

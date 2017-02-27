namespace SharpStore.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using ViewModels;

    public class KnivesService
    {
        private readonly SharpStoreContext context;

        public KnivesService(SharpStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            var knives = this.context.Knives.ToArray();
            var productViewModels = new List<ProductViewModel>();

            foreach (var knife in knives)
            {
                productViewModels.Add(new ProductViewModel()
                {
                    Id = knife.Id,
                    Name = knife.Name,
                    Price = knife.Price,
                    Url = knife.ImageUrl
                });
            }

            return productViewModels;
        }
    }
}

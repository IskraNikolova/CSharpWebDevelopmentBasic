namespace SharpStore.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using ViewModels;

    public class KnivesService : Service
    {
        public KnivesService(SharpStoreContext context) 
            : base(context)
        {
        }

        public IEnumerable<ProductViewModel> GetProducts(string productName)
        {
            var knives = context.Knives
                .Where(kn => kn.Name.Contains(productName))
                .ToArray();

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

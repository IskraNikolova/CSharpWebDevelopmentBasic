﻿namespace SharpStore.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using ViewModels;

    public class KnivesService
    {
        private readonly SharpStoreContext context;

        public KnivesService(SharpStoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductViewModel> GetProduct()
        {
            var knives = this.context.Knives.ToArray(); 
            var productViewModel = new List<ProductViewModel>();

            foreach (var knife in knives)
            {
                productViewModel.Add(new ProductViewModel()
                {
                    Id = knife.Id,
                    Name = knife.Name,
                    Price = knife.Price,
                    Url = knife.ImageUrl
                });
            }

            return productViewModel;
        }
    }
}
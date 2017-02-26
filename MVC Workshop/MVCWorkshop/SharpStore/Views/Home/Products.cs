namespace SharpStore.Views.Home
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class Products : IRenderable<IEnumerable<ProductViewModel>>

    {
        public IEnumerable<ProductViewModel> Model { get; set; }

        public string Render()
        {
            string template = File.ReadAllText("../../content/products.html");
            StringBuilder builder = new StringBuilder();
            foreach (var model in this.Model)
            {
                builder.Append(model);
            }

            return string.Format(template, builder);
        }

    }
}

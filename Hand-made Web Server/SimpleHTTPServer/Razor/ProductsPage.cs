namespace Razor
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SharpStore.Data.Models;

    public class ProductsPage : Page
    {
        private readonly IList<Knife> knives;

        public ProductsPage(string htmlPath, IList<Knife> knives) 
            : base(htmlPath)
        {
            this.knives = knives;
        }

        public override string ToString()
        {
            StringBuilder knivesBuilder = new StringBuilder();

            foreach (var knife in this.knives)
            {
                knivesBuilder.Append("<div class=\"col-sm-4\">\r\n" +
                                        "<div class=\"thumbnail\">\r\n" +
                                            $"<img src=\"{knife.ImageUrl}\" alt=\"...\">\r\n " +
                                            "<div class=\"caption\">\r\n " +
                                                $"<h3>{knife.Name}</h3>\r\n" +
                                                $"<p>${knife.Price}</p>\r\n" +
                                                "<button type=\"button\" class=\"btn btn-primary \">Buy Now</button>\r\n" +
                                            "</div>\r\n" +
                                          "</div>\r\n" +
                                         "</div>");
            }

            return String.Format(base.ToString(), knivesBuilder);
        }
    }
}

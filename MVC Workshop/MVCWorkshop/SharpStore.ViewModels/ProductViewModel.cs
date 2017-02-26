namespace SharpStore.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            string template = "<div class=\"col - sm - 4\">" +
                              $"< img class=\"img-thumbnail\" src=\"{this.Url}\"/>" +
                              $"<h3>{this.Name}</h3>" +
                              $"<h5>${this.Price:F2}</h5>" +
                              "<button class=\"btn btn-primary\">Buy Now!</button></div>";
            return template;
        }
    }
}

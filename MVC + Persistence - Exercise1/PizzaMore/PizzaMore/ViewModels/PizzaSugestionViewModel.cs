namespace PizzaMore.ViewModels
{
    using System.Collections.Generic;
    using System.Text;
    using Models;

    public class PizzaSugestionViewModel
    {
        public string Email { get; set; }

        public ICollection<Pizza> PizzaSugestions { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("<nav class=\"navbar navbar-default\">" +
                           "<div class=\"container-fluid\">" +
                           "<div class=\"navbar-header\">" +
                           "<a class=\"navbar-brand\" href=\"/home/index\">PizzaMore</a>" +
                           "</div>" +
                           "<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">" +
                           "<ul class=\"nav navbar-nav\">" +
                           "<li ><a href=\"/menu/add\">Suggest Pizza</a></li>" +
                           "<li><a href=\"menu/suggestions\">Your Suggestions</a></li>" +
                           "</ul>" +
                           "<ul class=\"nav navbar-nav navbar-right\">" +
                           "<p class=\"navbar-text navbar-right\"></p>" +
                           "<p class=\"navbar-text navbar-right\"><a href=\"Home.exe?logout=true\" class=\"navbar-link\">Sign Out</a></p>" +
                           $"<p class=\"navbar-text navbar-right\">Signed in as {this.Email}</p>" +
                           "</ul> </div></div></nav>");
            builder.AppendLine("<div class=\"card-deck\">");

            foreach (var pizza in this.PizzaSugestions)
            {
                builder.AppendLine("<div class=\"card\">");
                builder.AppendLine($"<img class=\"card-img-top\" src=\"{pizza.ImageUrl}\" width=\"200px\"alt=\"Card image cap\">");
                builder.AppendLine("<div class=\"card-block\">");
                builder.AppendLine($"<h4 class=\"card-title\">{pizza.Title}</h4>");
                builder.AppendLine($"<p class=\"card-text\"><a href=\"DetailsPizza.exe?pizzaid={pizza.Id}\">Recipe</a></p>");
                builder.AppendLine("<form method=\"POST\">");
                builder.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"up\">Up</label></div>");
                builder.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"down\">Down</label></div>");
                builder.AppendLine($"<input type=\"hidden\" name=\"pizzaid\" value=\"{pizza.Id}\" />");
                builder.AppendLine("<input type=\"submit\" class=\"btn btn-primary\" value=\"Vote\" />");
                builder.AppendLine("</form>");
                builder.AppendLine("</div>");
                builder.AppendLine("</div>");
            }

            builder.AppendLine("</div>");

            return builder.ToString();
        }
    }
}

namespace MvcApp.Web.ViewModels
{
    using Data.Models;
    using Infrastucture.Mapping;

    public class SignedViewModel : IMapFrom<User>
    {
        public string Username { get; set; }

        public override string ToString()
        {
            return $"<li><a href=\"#\">Hello, {this.Username}</a></li>";
        }
    }
}
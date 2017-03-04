namespace MvcApp.Web.ViewModels
{
    public class SignedViewModel
    {
        public string Username { get; set; }

        public override string ToString()
        {
            return $"<span class=\"navbar-text\">Hello, {this.Username}</span>";
        }
    }
}
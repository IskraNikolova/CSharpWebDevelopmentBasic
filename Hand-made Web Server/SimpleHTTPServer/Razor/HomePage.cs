namespace Razor
{
    public class HomePage : Page
    {
        public HomePage(string htmlPath) 
            : base(htmlPath)
        {

        }

        public HomePage() : 
            this("../../content/home.html")
        {
            this.AddStyleByPath("bootstrap/css/bootstrap.min.css");
            this.AddStyleByPath("css/carousel.css");
        }
    }
}

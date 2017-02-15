namespace Razor
{
    public class AboutPage : Page
    {
        public AboutPage(string htmlPath)
            : base(htmlPath)
        {
        }

        public AboutPage() : 
            this("../../content/about.html")
        {
            this.AddStyleByPath("bootstrap/css/bootstrap.min.css");
            this.AddStyleByPath("css/carousel.css");
        }
    }
}

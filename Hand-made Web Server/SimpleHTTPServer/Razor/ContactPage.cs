namespace Razor
{
    public class ContactPage :Page
    {
        public ContactPage(string htmlPath) 
            : base(htmlPath)
        {
        }

        public ContactPage() : 
            this("../../content/contacts.html")
        {
            this.AddStyleByPath("bootstrap/css/bootstrap.min.css");
            this.AddStyleByPath("css/carousel.css");
        }
    }
}

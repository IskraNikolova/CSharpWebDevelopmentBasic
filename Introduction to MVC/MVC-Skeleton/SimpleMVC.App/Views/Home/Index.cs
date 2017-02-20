namespace SimpleMVC.App.Views.Home
{
    using Mvc.Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h1>Hello MVC!</h1>";
        }
    }
}

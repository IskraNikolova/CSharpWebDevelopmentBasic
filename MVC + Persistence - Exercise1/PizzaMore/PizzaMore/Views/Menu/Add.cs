namespace PizzaMore.Views.Menu
{
    using System.IO;
    using SimpleMVC.Interfaces;
    public class Add : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/addpizza.html");
        }
    }
}

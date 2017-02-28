namespace PizzaMore.Views.Users
{
    using System.IO;
    using SimpleMVC.Interfaces;
    public class SignUp :IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/signup.html");
        }
    }
}

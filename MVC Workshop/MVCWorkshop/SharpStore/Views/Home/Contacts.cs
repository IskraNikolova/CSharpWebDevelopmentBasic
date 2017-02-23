namespace SharpStore.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;

    public class Contacts : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/contacts.html");
        }
    }
}

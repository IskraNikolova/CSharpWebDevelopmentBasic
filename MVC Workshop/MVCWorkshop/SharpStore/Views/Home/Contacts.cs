namespace SharpStore.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;

    public class Contacts : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText(path: "../../content/contacts.html");
        }
    }
}

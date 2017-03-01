namespace PizzaMore.Views.Menu
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class Index : IRenderable<PizzaSugestionViewModel>
    {
        public PizzaSugestionViewModel Model { get; set; }

        public string Render()
        {
            string template = File.ReadAllText("../../content/menu.html");
            StringBuilder builder = new StringBuilder();
            builder.Append(this.Model);
           
            return string.Format(template, builder);
        }
    }
}
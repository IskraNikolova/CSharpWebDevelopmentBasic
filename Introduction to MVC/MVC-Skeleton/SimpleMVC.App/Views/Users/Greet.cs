namespace SimpleMVC.App.Views.Users
{
    using System.Text;
    using Mvc.Interfaces.Generic;
    using ViewModel;

    public class Greet : IRenderable<GreetViewModel>
    {
        public GreetViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<h3>Hello user with session id: {this.Model.SessionId}</h3>");

            return sb.ToString();
        }
    }
}

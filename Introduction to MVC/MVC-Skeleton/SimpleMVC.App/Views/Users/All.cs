namespace SimpleMVC.App.Views.Users
{
    using System.Text;
    using Mvc.Interfaces.Generic;
    using ViewModel;

    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<a href=\"../../home/index\">&lt; Home</a>");
            sb.AppendLine("<h3>All users</h3>");
            sb.AppendLine("<ul>");
            int idCount = 1;

            foreach (var userName in this.Model.Usernames)
            {
                sb.AppendLine($"<li><a href=\"profile?id={idCount}\">{userName}</a></li>");
                idCount++;
            }
            sb.AppendLine("</ul>");

            return sb.ToString();
        }
    }
}

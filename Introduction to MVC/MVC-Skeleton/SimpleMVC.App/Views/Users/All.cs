namespace SimpleMVC.App.Views.Users
{
    using System.Collections.Generic;
    using System.Text;
    using Mvc.Interfaces.Generic;
    using ViewModel;

    public class All : IRenderable<IEnumerable<AllUsernamesViewModel>>
    {
        public IEnumerable<AllUsernamesViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"/home/index\">-Home</a>");
            sb.AppendLine("<h3>All User</h3>");           
            sb.AppendLine("<ul>");
            foreach (var model in ((IRenderable<IEnumerable<AllUsernamesViewModel>>)this).Model)
            {
                sb.AppendLine($"<li><a href=\"/users/profile?id={model.Id}\">{model.Username}</a></li>");
            }

            sb.AppendLine("</ul>");
            return sb.ToString();
        }
    }
}

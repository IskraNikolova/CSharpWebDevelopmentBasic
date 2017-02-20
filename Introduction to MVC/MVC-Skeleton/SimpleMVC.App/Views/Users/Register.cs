namespace SimpleMVC.App.Views.Users
{
    using System.Text;
    using Mvc.Interfaces.Generic;
    using ViewModel;

    public class Register : IRenderable<UserViewModel>
    {
        public UserViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"/home/index\">-Home</a>");
            sb.AppendLine("<h3>Register New User</3>");
            sb.AppendLine("<form action=\"register\" method=\"POST\"></br>");
            sb.AppendLine("Username: <input type=\"text\" name=\"Username\"/></br>");
            sb.AppendLine("Password: <input type=\"password\" name=\"Password\"/></br>");
            sb.AppendLine("<input type=\"submit\" value=\"Register\"/></br>");
            sb.AppendLine("</form></br>");

            return sb.ToString();
        }
    }
}

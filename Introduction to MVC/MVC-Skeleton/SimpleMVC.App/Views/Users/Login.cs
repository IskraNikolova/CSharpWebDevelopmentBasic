namespace SimpleMVC.App.Views.Users
{
    using System.Text;
    using Mvc.Interfaces;

    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"/home/index\">-Home</a>");
            sb.AppendLine("<h3>Login</3>");
            sb.AppendLine("<form action=\"login\" method=\"POST\"></br>");
            sb.AppendLine("Username: <input type=\"text\" name=\"Username\"/></br>");
            sb.AppendLine("Password: <input type=\"password\" name=\"Password\"/></br>");
            sb.AppendLine("<input type=\"submit\" value=\"Log In\"/></br>");
            sb.AppendLine("</form></br>");

            return sb.ToString();
        }
    }
}
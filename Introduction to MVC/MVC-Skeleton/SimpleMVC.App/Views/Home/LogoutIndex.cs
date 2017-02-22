using System;
namespace SimpleMVC.App.Views.Home
{
    using System.Text;
    using Mvc.Interfaces;

    public class LogoutIndex : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h1>NotesApp</h1>");
            sb.AppendLine("<a href=\"/users/all\">All Users</a>");
            sb.AppendLine("<a href=\"/users/logout\">Log Out</a>");

            return sb.ToString();
        }
    }
}

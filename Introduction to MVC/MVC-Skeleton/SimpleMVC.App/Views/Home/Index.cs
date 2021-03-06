﻿namespace SimpleMVC.App.Views.Home
{
    using System.Text;
    using Mvc.Interfaces;
    using SimpleHttpServer.Models;

    public class Index : IRenderable
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h1>NotesApp</h1>");
            sb.AppendLine("<a href=\"/users/all\">All Users</a>");
            sb.AppendLine("<a href=\"/users/register\">Register Users</a>");
            sb.AppendLine("<a href=\"/users/login\">Log In</a>");

            return sb.ToString();
        }
    }
}

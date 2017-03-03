﻿namespace MvcApp.Web.Views.Home
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    public class Index : IRenderable
    {
        public string Render()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(File.ReadAllText(Constants.ContantPath));
            return builder.ToString();
        }
    }
}

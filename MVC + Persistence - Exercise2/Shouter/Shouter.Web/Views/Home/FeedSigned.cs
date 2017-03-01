﻿namespace Shouter.Web.Views.Home
{
    using System;
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    public class FeedSigned : IRenderable<SignedViewModel>
    {
        public SignedViewModel Model { get; set; }

        public string Render()
        {
            string template = File.ReadAllText("../../Content/feed-signed.html");
            //var format = string.Format(template, this.Model);

            return template;
        }
    }
}
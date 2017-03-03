namespace MvcApp.Web.Views.Categories
{
    using System;
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    public class All : IRenderable<AllViewModel>
    {
        public AllViewModel Model { get; set; }

        public string Render()
        {
            string header = File.ReadAllText(Constants.ContentPath + Constants.Header);
            string navigation = File.ReadAllText(Constants.ContentPath + Constants.NavLogged);
            navigation = string.Format(navigation, this.Model.SignedModel.Username);
            string adminCategories = File.ReadAllText(Constants.ContentPath + Constants.AdminCategories);
            adminCategories  = String.Format(adminCategories, this.Model);
            string footer = File.ReadAllText(Constants.ContentPath + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(adminCategories);
            builder.Append(footer);

            return builder.ToString();
        }
    }
}

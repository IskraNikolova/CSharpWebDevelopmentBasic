namespace MvcApp.Web.Views.Users
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class Register : IRenderable//<HashSet<RegisterValidationModel>>
    {
        //public HashSet<RegisterValidationModel> Model { get; set; }

        public string Render() 
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(File.ReadAllText(Constants.ContentPath + "header.html"));
            builder.Append(File.ReadAllText(Constants.ContentPath + "menu.html"));

            //foreach (var message in this.Model)
            //{
            //    builder.Append(message);
            //}

            builder.Append(File.ReadAllText(Constants.ContentPath + "register.html"));
            builder.Append(File.ReadAllText(Constants.ContentPath + "footer.html"));

            return builder.ToString();
        }
    }
}
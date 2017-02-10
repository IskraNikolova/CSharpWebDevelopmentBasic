namespace AddPizza
{
    using System.Collections.Generic;
    using PizzaMore.Data;
    using PizzaMore.Data.Models;
    using PizzaMore.Utility;

    class AddPizza
    {
        private static IDictionary<string, string> PostParams;
        private static Header Header = new Header();

        static void Main(string[] args)
        {
            var session = WebUtil.GetSession();
            if (session == null)
            {
                Header.Print();
                WebUtil.PageNotAllowed();
                return;
            }

            if (WebUtil.IsGet())
            {
                ShowPage();
            }
            else if (WebUtil.IsPost())
            {
                PostParams = WebUtil.RetrievePostParameters();
                using (var ctx = new PizzaMoreContext())
                {
                    var user = ctx.Users.Find(session.UserId);
                    user.Pizzas.Add(new Pizza()
                    {
                        Title = PostParams["title"],
                        Recipe = PostParams["recipe"],
                        ImageUrl = PostParams["url"],
                        UpVotes = 0,
                        DownVotes = 0,
                        OwnerId = user.Id
                    });

                    ctx.SaveChanges();
                }

                ShowPage();
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent("../htdocs/pm/addpizza.html");
        }
    }
}

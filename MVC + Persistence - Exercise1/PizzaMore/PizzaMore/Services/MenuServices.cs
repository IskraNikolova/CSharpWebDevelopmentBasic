namespace PizzaMore.Services
{
    using System.Linq;
    using Data;
    using SimpleHttpServer.Models;
    using ViewModels;

    public class MenuServices
    {
        public PizzaSugestionViewModel GetModel(HttpSession session)
        {
            using (var context = Data.Context)
            {
                var user = context
                          .Sessions
                          .First(s => s.SessionId == session.Id)
                          .User;

                var viewModel = new PizzaSugestionViewModel()
                {
                    Email = user.Email,
                    PizzaSugestions = user.Pizzas
                };

                return viewModel;
            }
        }
    }
}
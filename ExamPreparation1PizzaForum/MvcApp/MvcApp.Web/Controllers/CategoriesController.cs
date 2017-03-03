namespace MvcApp.Web.Controllers
{
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using Security;
    using SimpleHttpServer.Models;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class CategoriesController : Controller
    {
        private readonly IDeletableEntityRepository<Session> sessions;
        private readonly AuthenticationManager manager;

        public CategoriesController()
        {
            this.sessions = new DeletableEntityRepository<Session>(MvcAppContext.Create());
            this.manager = new AuthenticationManager(this.sessions);
        }
        public IActionResult All(HttpSession session, HttpResponse response)
        {
            if (!this.manager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "forum/register");
                return null;
            }

            User user = this.manager.GetAuthenticationUser(session.Id);
            if (!user.IsAdmin)
            {
                this.Redirect(response, "home/topics");
                return null;
            }

            return this.View();
        }
    }
}

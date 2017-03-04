namespace MvcApp.Web.Services.Home
{
    using System.Linq;
    using Data;
    using Data.Models;
    using SimpleHttpServer.Models;

    public class HomeIndexService : Service
    {
        public HomeIndexService(UnitOfWork unit) 
            : base(unit)
        {
        }

        public User GetAutenticationUser(HttpSession session)
        {
            return this.unit.Sessions
                                  .All()
                                  .FirstOrDefault(s => s.LoginId == session.Id)?
                                  .User;
        }
    }
}

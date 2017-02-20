namespace SimpleMVC.App.Controllers
{
    using Mvc.Controllers;
    using Mvc.Interfaces;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

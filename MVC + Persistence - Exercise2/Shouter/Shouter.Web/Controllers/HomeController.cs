namespace Shouter.Web.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Feed()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
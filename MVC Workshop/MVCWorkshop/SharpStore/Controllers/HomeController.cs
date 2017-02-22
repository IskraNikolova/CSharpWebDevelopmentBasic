namespace SharpStore.Controllers
{
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
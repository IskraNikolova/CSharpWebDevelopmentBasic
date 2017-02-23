namespace SharpStore.Controllers
{
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Products()
        {
            return this.View();
        }


        //[HttpPost]
        //public IActionResult Products(todo)
        //{
        //    return this.View();
        //}

        [HttpGet]
        public IActionResult Contacts()
        {
            return this.View();
        }
    }
}
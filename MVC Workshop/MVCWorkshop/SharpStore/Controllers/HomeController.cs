namespace SharpStore.Controllers
{
    using System.Collections.Generic;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using ViewModels;

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
            List<ProductViewModel> views = new List<ProductViewModel>();
            return this.View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return this.View();
        }
    }
}
namespace SharpStore.Controllers
{
    using System.Collections.Generic;
    using BindingModels;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
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
        public IActionResult<IEnumerable<ProductViewModel>> Products(string productName)
        {
            KnivesService services = new KnivesService(Data.Data.Context);
            IEnumerable<ProductViewModel> views = services.GetProducts(productName);

            return this.View(views);
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Contacts(MessageBinding messageBindingModel)
        {
            if (string.IsNullOrEmpty(messageBindingModel.Messagetext) ||
                string.IsNullOrEmpty(messageBindingModel.Subject) ||
                string.IsNullOrEmpty(messageBindingModel.Email))
            {
               this.Redirect(new HttpResponse(), "/home/contacts"); 
            }

            MessagesService service = new MessagesService(Data.Data.Context);
            service.AddMessageFromBind(messageBindingModel);

            return this.View("Home", "Index");
        }

        [HttpGet]
        public IActionResult Buy()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Buy(BuyerBindingModel model)
        {
            BuyerService service = new BuyerService(Data.Data.Context);
            service.AddPurchase(model);

            return this.View("Home", "Index");
        }
    }
}
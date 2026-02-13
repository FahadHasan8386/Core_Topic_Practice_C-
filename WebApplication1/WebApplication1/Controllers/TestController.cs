using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var testModel = new TestModel
            {
                Name = "Fahad"
            };

            return View(testModel);
        }


        public IActionResult Create()
        {
            return View();
        }
    }

    public class TestModel {
        public string Name { get; set; }
    }

}

using CLVD_POE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLVD_POE.Controllers
{
    // This method is used to display the products in the database
    public class ProductDisplay : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var products = DisplayProduct.SelectProducts();
            return View(products);
        }
    }
}

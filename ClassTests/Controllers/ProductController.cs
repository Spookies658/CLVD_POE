using CLVD_POE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLVD_POE.Controllers
{
    public class ProductController : Controller
    {
        public ProductTable prodtbl = new ProductTable();
        // This method redirects the user to the Home page
        [HttpPost]
        public ActionResult MyWork(ProductTable products)
        {
            var result2 = prodtbl.insert_product(products);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult MyWork()
        {
            return View(prodtbl);
        }
    }
}
   


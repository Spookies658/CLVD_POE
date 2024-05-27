using CLVD_POE.Models;
using Microsoft.AspNetCore.Mvc;


namespace CLVD_POE.Controllers
{
    // Returns the user to the home page once they have successfully registered
    public class UserController : Controller
    {
        public userTable usrtbl = new userTable();

        [HttpPost]
        public ActionResult About(userTable Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult About()
        {
            return View(usrtbl);
        }

    }
}

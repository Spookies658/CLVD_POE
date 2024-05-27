using CLVD_POE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLVD_POE.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }
        // THis method returns the user to the home page once they have successfully logged in
        [HttpPost]
        public ActionResult Privacy(string email, string name)
        {
            var loginModel = new LoginModel();
            int userID = loginModel.SelectUser(email, name);
            if (userID != -1)
            {
                
                HttpContext.Session.SetInt32("UserID", userID);

                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                
                return View("LoginFailed");
            }
        }

    }
}

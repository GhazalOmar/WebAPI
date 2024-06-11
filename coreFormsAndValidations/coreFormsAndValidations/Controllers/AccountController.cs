using coreFormsAndValidations.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreFormsAndValidations.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult WeaklyTypedLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPost(string username, string password)
        {
            ViewBag.Username = username;
            ViewBag.Password = password;

            return View();  
        }

        public IActionResult StronglyTypedLogin() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginSuccess(LoginViewModel login)
        {
            if(login.Username != null && login.Password != null)
            {
                if(login.Username.Equals("admin") && login.Password.Equals("admin"))
                {
                    ViewBag.Message = "you are successfully logged in";
                    return View();
                }
            };
            ViewBag.Message = "Invalid Credintials";
            return View();
        }

        public IActionResult UserDetail()
        {
            var user = new LoginViewModel() { Username = "ghazal", Password = "123456" };
            return View(user);
        }

        public IActionResult UserList()
        {
            var users = new List<LoginViewModel>()
            {
                new LoginViewModel() { Username = "ghazal", Password = "123456"},
                new LoginViewModel() { Username = "own", Password = "123956"},
                new LoginViewModel() { Username = "layan", Password = "113456"},
            };

            return View(users);
        }

        public IActionResult GetAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostAccount(Account account)
        {
            if(ModelState.IsValid)
            {
                return View("Success");
            }
            return RedirectToAction("GetAccount");
        }
    }
}

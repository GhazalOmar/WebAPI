using coreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreWebApplication.Controllers
{
    public class CustomerController1 : Controller
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer() {Id = 101, Name = "Ghazal", Amount = 12000},
            new Customer() {Id = 101, Name = "Ghazal", Amount = 12000},

        };
        public IActionResult Index()
        {
            ViewBag.Message = "Customer Managmenet System";
            ViewBag.CustomerCount = customers.Count;
            ViewBag.CustomerList = customers;
            return View();
        }

        public IActionResult Details()
        {
            ViewData["Message"] = "Customer Managmenet System";
            ViewData["CustomerCount"] = customers.Count();
            ViewData["CustomerList"]= customers;
            return View();
        }
        public IActionResult Method1()
        {
            TempData["Message"] = "Customer Managmenet System";
            TempData["CustomerCount"] = customers.Count();
            TempData["CustomerList"] = customers;
            return View();
        }

        public IActionResult Method2()
        {
            if (TempData["Message"] == null)
            {
                return RedirectToAction("Index");
            }
            TempData["Message"] = TempData["Message"].ToString();
            return View();
        }

        public IActionResult Login()
        {
            HttpContext.Session.SetString("username", "Ghazal");
            return RedirectToAction("Success");
        }

        public IActionResult Success() 
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }

        public IActionResult QueryTest()
        {
            string name = "Ghazal Alosta";
            if (!String.IsNullOrEmpty(HttpContext.Request.Query["name"]))
                name = HttpContext.Request.Query["name"];
            ViewBag.Name = name;
            return View();
        }

        //[Route("~/")] -> default
        [Route("/sample/message")]
        public IActionResult Message()
        {
            return View();  
        }
    }
}

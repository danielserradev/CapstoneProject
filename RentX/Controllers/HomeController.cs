using Microsoft.AspNet.Identity;
using RentX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentX.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;
        public HomeController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            if (User.IsInRole("Leasor"))
            {

                //Leasor  leasor = context.Leasors.Where(e => e.ApplicationId == userId).FirstOrDefault();
                //return RedirectToAction("GetPickupsToday", "Employees", employee);
            }
            else if (User.IsInRole("Renter"))
            {
                //Customer customer = context.Customers.Where(c => c.ApplicationId == userId).FirstOrDefault();
                //return RedirectToAction("Details", "Customers", customer);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
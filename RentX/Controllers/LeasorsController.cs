using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using RentX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RentX.Controllers
{
    public class LeasorsController : Controller
    {
        ApplicationDbContext context;
        public LeasorsController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Leasors
        public ActionResult Index()
        {
            return View(context.Leasors.ToList());
        }

        // GET: Leasors/Details/5
        public ActionResult Details(int id)
        {
            Leasor leasor = context.Leasors.Where(l => l.LeasorId == id).FirstOrDefault();
            return View(leasor);
        }

        // GET: Leasors/Create
        public ActionResult Create()
        {
            Leasor leasor = new Leasor();
            return View(leasor);
        }

        // POST: Leasors/Create
        [HttpPost]
        public async Task<ActionResult> Create(Leasor leasor)
        {
            try
            {
                // TODO: Add insert logic here                
                context.Leasors.Add(leasor);
                string requesturl = "https://maps.googleapis.com/maps/api/geocode/json?address=";
                string userAddress = System.Web.HttpUtility.UrlEncode(
                    leasor.StreetAddress + " " +
                    leasor.City + " " +
                    leasor.StateCode + " " +
                    leasor.ZipCode);
                string apiKey = APIKeys.GeoCodeApi;
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(requesturl + userAddress + apiKey);
                JObject map = JObject.Parse(response);
                leasor.Lat = (float)map["results"][0]["geometry"]["location"]["lat"];
                leasor.Lng = (float)map["results"][0]["geometry"]["location"]["lng"];
                string id = User.Identity.GetUserId();
                leasor.ApplicationId = id;
                context.SaveChanges();

                return RedirectToAction("Details", "Leasors", leasor);
            }
            catch
            {
                return View();
            }
        }

        // GET: Leasors/Edit/5
        public ActionResult Edit(int id)
        {
            Leasor leasor = context.Leasors.Where(l => l.LeasorId == id).FirstOrDefault();
            return View(leasor);
        }

        // POST: Leasors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Leasor leasor)
        {
            try
            {
                // TODO: Add update logic here
                Leasor leasorToEdit = context.Leasors.Where(l => l.LeasorId == id).FirstOrDefault();
                leasorToEdit.FirstName = leasor.FirstName;
                leasorToEdit.LasttName = leasor.LasttName;
                leasorToEdit.EmailAddress = leasor.EmailAddress;
                leasorToEdit.StreetAddress = leasor.StreetAddress;
                leasorToEdit.ZipCode = leasor.ZipCode;
                leasorToEdit.StateCode = leasor.StateCode;
                context.SaveChanges();                
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Leasors/Delete/5
        public ActionResult Delete(int id)
        {
            Leasor leasor = context.Leasors.Where(l => l.LeasorId == id).FirstOrDefault();
            return View(leasor);
        }

        // POST: Leasors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Leasor leasor)
        {
            try
            {
                // TODO: Add delete logic here
                Leasor leasorToDelete = context.Leasors.Where(l => l.LeasorId == id).FirstOrDefault();
                context.Leasors.Remove(leasorToDelete);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}

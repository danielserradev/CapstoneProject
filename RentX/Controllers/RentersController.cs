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
    public class RentersController : Controller
    {
        ApplicationDbContext context;
        public RentersController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Renters
        public ActionResult Index()
        {
            return View(context.Renters.ToList());
        }

        // GET: Renters/Details/5
        public ActionResult Details(int id)
        {
            Renter renter = context.Renters.Where(r => r.RenterId == id).FirstOrDefault();
            return View(renter);
        }

        // GET: Renters/Create
        public ActionResult Create()
        {
            Renter renter = new Renter();
            return View(renter);
        }

        // POST: Renters/Create
        [HttpPost]
        public async Task<ActionResult> Create(Renter renter)
        {
            try
            {
                // TODO: Add insert logic here                
                context.Renters.Add(renter);
                string requesturl = "https://maps.googleapis.com/maps/api/geocode/json?address=";
                string userAddress = System.Web.HttpUtility.UrlEncode(
                    renter.StreetAddress + " " +
                    renter.City + " " +
                    renter.StateCode + " " +
                    renter.ZipCode);
                string apiKey = APIKeys.GeoCodeApi;
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(requesturl + userAddress + apiKey);
                JObject map = JObject.Parse(response);
                renter.Lat = (float)map["results"][0]["geometry"]["location"]["lat"];
                renter.Lng = (float)map["results"][0]["geometry"]["location"]["lng"];
                string id = User.Identity.GetUserId();
                renter.ApplicationId = id;
                context.SaveChanges();
                return RedirectToAction("Deatails", "Renters", renter);
            }
            catch
            {
                return View();
            }
        }

        // GET: Renters/Edit/5
        public ActionResult Edit(int id)
        {
            Renter renter = context.Renters.Where(r => r.RenterId == id).FirstOrDefault();
            return View(renter);
        }

        // POST: Renters/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Renter renter)
        {
            try
            {
                // TODO: Add update logic here
                Renter renterToEdit = context.Renters.Where(r => r.RenterId == id).FirstOrDefault();
                renterToEdit.FirstName = renter.FirstName;
                renterToEdit.LasttName = renter.LasttName;
                renterToEdit.EmailAddress = renter.EmailAddress;
                renterToEdit.StreetAddress = renter.StreetAddress;
                renterToEdit.ZipCode = renter.ZipCode;
                renterToEdit.StateCode = renter.StateCode;
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Renters/Delete/5
        public ActionResult Delete(int id)
        {
            Renter renter = context.Renters.Where(r => r.RenterId == id).FirstOrDefault();
            return View(renter);
        }

        // POST: Renters/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Renter renter)
        {
            try
            {
                // TODO: Add delete logic here
                Renter renterToDelete = context.Renters.Where(r => r.RenterId == id).FirstOrDefault();
                context.Renters.Remove(renterToDelete);
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

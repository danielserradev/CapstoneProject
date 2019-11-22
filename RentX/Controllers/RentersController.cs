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
        SMSController sendText;
        public RentersController()
        {
            context = new ApplicationDbContext();
            sendText = new SMSController();
        }

        public ActionResult GetAllItemsForRent()
        {
            return View(context.Items.ToList());
        }
        public ActionResult GetPaymentRequests(int id)
        {
            List<PaymentRequest> paymentRequests = context.PaymentRequests.Where(p => p.RenterId == id).ToList();
            return View(paymentRequests);
        }
        public ActionResult PayRequest(int id, int ItemId)
        {
            Renter renter = context.Renters.Where(r => r.RenterId == id).FirstOrDefault();
            Item item = context.Items.Where(i => i.ItemId == ItemId).FirstOrDefault();
            Transaction transaction = new Transaction();
            transaction.RenterId = renter.RenterId;
            transaction.ItemId = item.ItemId;
            transaction.TimeOfPayment = DateTime.Now;
            context.Transactions.Add(transaction);
            context.SaveChanges();
            Leasor leasor = context.Leasors.Where(l => l.LeasorId == item.LeasorId).FirstOrDefault();
            sendText.SendSMSToLeasorToNotifyOfTransaction(leasor);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AddSelfToQueue(int id)
        {
            var item = context.Items.Where(i => i.ItemId == id).FirstOrDefault();
            string appId = User.Identity.GetUserId();
            Renter renter = context.Renters.Where(r => r.ApplicationId == appId).FirstOrDefault();
            Queue queue = context.Queues.Where(q => q.ItemId == item.ItemId).FirstOrDefault();

            QueueRenter queueRenter = new QueueRenter();
            context.QueueRenters.Add(queueRenter);
            queueRenter.QueueId = queue.QueueId;
            queueRenter.RenterId = renter.RenterId; 


            context.SaveChanges();
            Leasor leasor = context.Leasors.Where(l => l.LeasorId == item.LeasorId).FirstOrDefault();
            sendText.SendSMSToLeasorToNotifyRenterAddedToQueue(leasor);
            return RedirectToAction("Index", "Home");
            
        }
        public ActionResult GetListOfLeasors()
        {

            return View(context.Leasors.ToList());
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
                return RedirectToAction("Index", "Home");
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

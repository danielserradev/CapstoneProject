using Microsoft.AspNet.Identity;
using RentX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentX.Controllers
{
    public class ItemsController : Controller
    {
        ApplicationDbContext context;
        public ItemsController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Items
        public ActionResult Index()
        {
            return View(context.Items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int id)
        {
            Item item = context.Items.Where(i => i.ItemId == id).FirstOrDefault();
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            Item item = new Item();
            return View(item);
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(Item item)
        {
            try
            {
                // TODO: Add insert logic here
                
                

                string id = User.Identity.GetUserId();
                var leaser = context.Leasors.Where(u => u.ApplicationId == id).FirstOrDefault();
                //var renter = context.Renters.Where(r => r.ApplicationId == id).FirstOrDefault();
                item.LeasorId = leaser.LeasorId;
                //item.RenterId = renter.RenterId;
                context.Items.Add(item);                
                context.SaveChanges();
                Queue queue = new Queue();
                queue.ItemId = item.ItemId;
                context.Queues.Add(queue);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch(Exception e)
            {

                return View();
            }
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int id)
        {
            Item item = context.Items.Where(i => i.ItemId == id).FirstOrDefault();
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Item item)
        {
            try
            {
                // TODO: Add update logic here
                Item itemToEdit = context.Items.Where(i => i.ItemId == id).FirstOrDefault();
                itemToEdit.Name = item.Name;
                itemToEdit.Price = item.Price;
                itemToEdit.Image = item.Image;
                itemToEdit.RentCounter = item.RentCounter;
                itemToEdit.Availability = item.Availability;
                itemToEdit.NumOfMonthsForRent = item.NumOfMonthsForRent;
                itemToEdit.StartDate = item.StartDate;
                itemToEdit.EndDate = item.EndDate;
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int id)
        {
            Item item = context.Items.Where(i => i.ItemId == id).FirstOrDefault();
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Item item)
        {
            try
            {
                // TODO: Add delete logic here
                Item itemToDelete = context.Items.Where(i => i.ItemId == id).FirstOrDefault();
                context.Items.Remove(itemToDelete);
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

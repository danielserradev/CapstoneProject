using Microsoft.AspNet.Identity;
using RentX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentX.Controllers
{
    public class QueuesController : Controller
    {
        ApplicationDbContext context;
        public QueuesController()
        {
            context = new ApplicationDbContext();
        }


        // GET: Queues
        public ActionResult Index()
        {
            return View(context.Queues.ToList());
        }

        // GET: Queues/Details/5
        public ActionResult Details(int id)
        {
            Queue queue = context.Queues.Where(q => q.QueueId == id).FirstOrDefault();
            return View(queue);
        }

        // GET: Queues/Create
        public ActionResult Create()
        {
            Queue queue = new Queue();
            return View(queue);
        }

        // POST: Queues/Create
        [HttpPost]
        public ActionResult Create(Queue queue)
        {
            try
            {
                // TODO: Add insert logic here
                context.Queues.Add(queue);
                context.SaveChanges();
                

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Queues/Edit/5
        public ActionResult Edit(int id)
        {
            Queue queue = context.Queues.Where(q => q.QueueId == id).FirstOrDefault();
            return View(queue);
        }

        // POST: Queues/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Queue queueToEdit = context.Queues.Where(q => q.QueueId == id).FirstOrDefault();
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Queues/Delete/5
        public ActionResult Delete(int id)
        {
            Queue queue = context.Queues.Where(q => q.QueueId == id).FirstOrDefault();
            return View(queue);
        }

        // POST: Queues/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Queue queueToDelete = context.Queues.Where(q => q.QueueId == id).FirstOrDefault();
                context.Queues.Remove(queueToDelete);
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

using RentX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentX.Controllers
{
    public class RatingQueuesController : Controller
    {
        ApplicationDbContext context;
        public RatingQueuesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: RatingQueues
        public ActionResult Index()
        {
            return View();
        }

        // GET: RatingQueues/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RatingQueues/Create
        public ActionResult Create()
        {
            RatingQueue ratingQueue = new RatingQueue();
            return View();
        }

        // POST: RatingQueues/Create
        [HttpPost]
        public ActionResult Create(RatingQueue ratingQueue)
        {
            try
            {
                // TODO: Add insert logic here
                context.RatingQueues.Add(ratingQueue);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RatingQueues/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RatingQueues/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RatingQueues/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RatingQueues/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

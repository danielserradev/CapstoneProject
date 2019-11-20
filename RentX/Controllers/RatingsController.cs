using Microsoft.AspNet.Identity;
using RentX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentX.Controllers
{
    public class RatingsController : Controller
    {
        ApplicationDbContext context;
        public RatingsController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Ratings
        public ActionResult Index()
        {
            return View(context.Ratings.ToList());
        }

        // GET: Ratings/Details/5
        public ActionResult Details(int id)
        {
            Rating rating = context.Ratings.Where(r => r.RatingId == id).FirstOrDefault();
            return View();
        }

        // GET: Ratings/Create
        public ActionResult Create()
        {
            Rating rating = new Rating();
            return View(rating);
        }

        // POST: Ratings/Create
        [HttpPost]
        public ActionResult Create(Rating rating)
        {
            try
            {
                // TODO: Add insert logic here
                
                
                string id = User.Identity.GetUserId();
                var leaser = context.Leasors.Where(u => u.ApplicationId == id).FirstOrDefault();
                var renter = context.Renters.Where(r => r.ApplicationId == id).FirstOrDefault();
                rating.LeasorId = leaser.LeasorId;
                rating.RenterId = renter.RenterId;
                context.Ratings.Add(rating);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ratings/Edit/5
        public ActionResult Edit(int id)
        {
            Rating rating = context.Ratings.Where(r => r.RatingId == id).FirstOrDefault();
            return View(rating);
        }

        // POST: Ratings/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Rating rating)
        {
            try
            {
                // TODO: Add update logic here
                Rating ratingToEdit = context.Ratings.Where(r => r.RatingId == id).FirstOrDefault();
                ratingToEdit.NumOfStars = rating.NumOfStars;
                ratingToEdit.Review = rating.Review;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ratings/Delete/5
        public ActionResult Delete(int id)
        {
            Rating rating = context.Ratings.Where(r => r.RatingId == id).FirstOrDefault();
            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Rating rating)
        {
            try
            {
                // TODO: Add delete logic here
                Rating ratingToDelete = context.Ratings.Where(r => r.RatingId == id).FirstOrDefault();
                context.Ratings.Remove(ratingToDelete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

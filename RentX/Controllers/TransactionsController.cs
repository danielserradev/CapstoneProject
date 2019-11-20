using Microsoft.AspNet.Identity;
using RentX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentX.Controllers
{
    public class TransactionsController : Controller
    {
        ApplicationDbContext context;
        public TransactionsController()
        {
            context = new ApplicationDbContext();
        }            
        // GET: Transactions
        public ActionResult Index()
        {
            return View(context.Transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int id)
        {
            Transaction transaction = context.Transactions.Where(t => t.TransactionId == id).FirstOrDefault();
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            Transaction transaction = new Transaction();
            return View(transaction);
        }

        // POST: Transactions/Create
        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            try
            {
                // TODO: Add insert logic here
                string id = User.Identity.GetUserId();
                var leaser = context.Leasors.Where(l => l.ApplicationId == id).FirstOrDefault();
                var renter = context.Renters.Where(r => r.ApplicationId == id).FirstOrDefault();
                transaction.LeasorId = leaser.LeasorId;
                transaction.RenterId = renter.RenterId;
                transaction.TimeOfPayment = DateTime.Now;
                


                context.Transactions.Add(transaction);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int id)
        {
            Transaction transaction = context.Transactions.Where(t => t.TransactionId == id).FirstOrDefault();
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Transaction transaction)
        {
            try
            {
                // TODO: Add update logic here
                Transaction transactionToEdit = context.Transactions.Where(t => t.TransactionId == id).FirstOrDefault();
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int id)
        {
            Transaction transaction = context.Transactions.Where(t => t.TransactionId == id).FirstOrDefault();
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Transaction transaction)
        {
            try
            {
                // TODO: Add delete logic here
                Transaction transactionToDelete = context.Transactions.Where(t => t.TransactionId == id).FirstOrDefault();
                context.Transactions.Remove(transactionToDelete);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRAVELANCAR.Models;

namespace TRAVELANCAR.Controllers
{
    public class KamarController : Controller
    {
        private kamarContext_Travelancar db = new kamarContext_Travelancar();

        //
        // GET: /Kamar/

        public ActionResult Index()
        {
            return View(db.kamar_univ.ToList());
        }

        //
        // GET: /Kamar/Details/5

        public ActionResult Details(int id = 0)
        {
            kamar_univ kamar_univ = db.kamar_univ.Find(id);
            if (kamar_univ == null)
            {
                return HttpNotFound();
            }
            return View(kamar_univ);
        }

        //
        // GET: /Kamar/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Kamar/Create

        [HttpPost]
        public ActionResult Create(kamar_univ kamar_univ)
        {
            if (ModelState.IsValid)
            {
                db.kamar_univ.Add(kamar_univ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kamar_univ);
        }

        //
        // GET: /Kamar/Edit/5

        public ActionResult Edit(int id = 0)
        {
            kamar_univ kamar_univ = db.kamar_univ.Find(id);
            if (kamar_univ == null)
            {
                return HttpNotFound();
            }
            return View(kamar_univ);
        }

        //
        // POST: /Kamar/Edit/5

        [HttpPost]
        public ActionResult Edit(kamar_univ kamar_univ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kamar_univ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kamar_univ);
        }

        //
        // GET: /Kamar/Delete/5

        public ActionResult Delete(int id = 0)
        {
            kamar_univ kamar_univ = db.kamar_univ.Find(id);
            if (kamar_univ == null)
            {
                return HttpNotFound();
            }
            return View(kamar_univ);
        }

        //
        // POST: /Kamar/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            kamar_univ kamar_univ = db.kamar_univ.Find(id);
            db.kamar_univ.Remove(kamar_univ);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
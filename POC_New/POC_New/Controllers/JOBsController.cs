using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POC_New.Models;

namespace POC_New.Controllers
{
    public class JOBsController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: JOBs
        public ActionResult Index()
        {
            return View(db.JOBS.ToList());
        }

        // GET: JOBs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JOB jOB = db.JOBS.Find(id);
            if (jOB == null)
            {
                return HttpNotFound();
            }
            return View(jOB);
        }

        // GET: JOBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JOBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JOB_ID,JOB_TITLE,MIN_SALARY,MAX_SALARY")] JOB jOB)
        {
            if (ModelState.IsValid)
            {
                db.JOBS.Add(jOB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jOB);
        }

        // GET: JOBs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JOB jOB = db.JOBS.Find(id);
            if (jOB == null)
            {
                return HttpNotFound();
            }
            return View(jOB);
        }

        // POST: JOBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JOB_ID,JOB_TITLE,MIN_SALARY,MAX_SALARY")] JOB jOB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jOB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jOB);
        }


        [HttpPost]
        public ActionResult Update(JOB job)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    JOB Ojob = db.JOBS.Single(j => j.JOB_ID == job.JOB_ID);
                    Ojob.JOB_ID = job.JOB_ID;
                    Ojob.JOB_TITLE = job.JOB_TITLE;
                    Ojob.MIN_SALARY = job.MIN_SALARY;
                    Ojob.MAX_SALARY = job.MAX_SALARY;

                    db.Entry(Ojob).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.Write(ex);
                }
                
            }
            return RedirectToAction("Index");
        }


        // GET: JOBs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JOB jOB = db.JOBS.Find(id);
            if (jOB == null)
            {
                return HttpNotFound();
            }
            return View(jOB);
        }

        // POST: JOBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            JOB jOB = db.JOBS.Find(id);
            db.JOBS.Remove(jOB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

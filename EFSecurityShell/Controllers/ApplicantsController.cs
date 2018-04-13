using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFSecurityShell.Models;

namespace EFSecurityShell.Controllers
{
    public class ApplicantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Applicants
        public ActionResult Index()
        {
            return View(db.Applicants.ToList());
        }

        // GET: Applicants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                Applicant matchingApplicant = db.Applicants.Where(cm => string.Compare(cm.SSN, applicant.SSN, true) == 0).FirstOrDefault();
                if (applicant == null)
                {
                    return HttpNotFound();
                }
                if (matchingApplicant != null)
                {
                    ModelState.AddModelError("SSN", "Social Security Number has already been used");
                    return View(applicant);
                }
                if (applicant.GPA < 3.0 || applicant.GPA > 4.0)
                {
                    ModelState.AddModelError("GPA", "GPA does not meet minimum requirements");
                    return View(applicant);
                }
                if ((applicant.Verbal + applicant.Math) < 1000)
                {
                    ModelState.AddModelError("Math", "Combined SAT scores do not meet minimum requirements (atleast 1000)");
                    ModelState.AddModelError("Verbal", "Combined SAT scores do not meet minimum requirements (atleast 1000)");
                    return View(applicant);
                }
            }
            db.Applicants.Add(applicant);
            db.SaveChanges();
            return View("ThankYou");
        }

        // GET: Applicants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SSN,FirstName,MiddleName,LastName,HomePhone,CellPhone,Address,Street,State,ZipCode,DOB,Gender,Name,City,GradDate,GPA,Math,Verbal,AOF,PED,Season,Year,Status")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            db.Applicants.Remove(applicant);
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

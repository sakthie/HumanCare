using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HumanCare.BLL;
using Humancare.Data;

namespace HumanCarePresentationLayer.Controllers
{
    public class PatientController : Controller
    {
        private HealthCareNewEntities db = new HealthCareNewEntities();
        PatientRepository patCon = new PatientRepository();
        //
        // GET: /Student/

        public ActionResult Index()
        {
            IEnumerable<Patient> patientList = patCon.getallPatient();
            return View(patientList);
            //return View(db.Patients.ToList());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(string id = null)
        {
            Patient patient = db.Patients.Single(p => p.patientId == id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Patients.AddObject(patient);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            if (ModelState.IsValid)
            {
                var patientid = from cs in db.Patients select cs.patientId;
                if (patientid.Count() <= 1)
                {
                    var a = patient.name.Substring(0, 3) + 100;
                }
                else
                {
                    var max_Id = (from a in db.Patients select a.patientId.Substring(3, 5)).Max();
                    patient.patientId = patient.name.Substring(0, 3) + (Convert.ToInt32(max_Id) + 1).ToString();
                }

                db.Patients.AddObject(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(patient);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(string id = null)
        {
            Patient patient = db.Patients.Single(p => p.patientId == id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                /*db.Patients.Attach(patient);
                db.ObjectStateManager.ChangeObjectState(patient, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");*/
            }
            return View(patient);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(string id = null)
        {
            Patient patient = db.Patients.Single(p => p.patientId == id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            Patient patient = db.Patients.Single(p => p.patientId == id);
            db.Patients.DeleteObject(patient);
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

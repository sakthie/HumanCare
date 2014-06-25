using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Humancare.Data;
using HumanCare.BLL;

namespace HumanCarePresentationLayer.Controllers
{
    public class PrescriptionController : Controller
    {
        //
        // GET: /Prescription/
        private HealthCareNewEntities db = new HealthCareNewEntities();
        private PrescriptionBs ppb = new PrescriptionBs();
        public ActionResult Index()
        {
            return View(db.Patient_Prescription);
        }
        public ActionResult AddPrescriptionView() {
            Patient_Prescription pp = new Patient_Prescription();
            pp.dateIssued = DateTime.Today;
            return View(pp);
        }
        [HttpPost]
        public ActionResult AddPrescription(Patient_Prescription pp) {
            ppb.AddNewPrescription(pp);
            return View();
        }
    }
}

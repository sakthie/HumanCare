using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Humancare.Data;
using HumanCare.BLL;

namespace HumanCarePresentationLayer.Controllers
{
    public class TreatmentController : Controller
    {
        private HealthCareNewEntities db = new HealthCareNewEntities();
       // PatientRepository patCon = new PatientRepository();
        //
        
        TreatmentBs tb = new TreatmentBs(); 
        //
        // GET: /Treatment/
        
        public ActionResult Index()
        {
            return View();
        }
        // TreateMent


        public ActionResult AddTreatmentView() {
            Patient_Treatment pt = new Patient_Treatment();
            pt.startDate = DateTime.Today;
            pt.endDate = DateTime.Today;
            return View(pt);
        }
        [HttpPost]
        public ActionResult AddTreatment(Patient_Treatment pt)
        {
           
            tb.addNewTreatement(pt);
            return View();
        }

        public ActionResult ListTreatment() {
            return View(db.Patient_Treatment);
        }

        
    }
}

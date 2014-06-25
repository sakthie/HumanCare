using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanCare.BLL.repositories;
using Humancare.Data;
using System.Data.Entity.Validation;

namespace HumanCarePresentationLayer.Areas.Doctor.Controllers
{
    public class DoctorController : Controller
    {
        private DoctorRepository doctorRepository = new DoctorRepository();
        private SpecializationRepository sr = new SpecializationRepository();
        HealthCareNewEntities entities = new HealthCareNewEntities();
        //
        // GET: /Humancare.Data.Doctor/Humancare.Data.Doctor/

        public ActionResult Index()
        {
            IEnumerable<Humancare.Data.Doctor> doctors = doctorRepository.getDoctors();
            return View(doctors);
        }

        //
        // GET: /Humancare.Data.Doctor/Humancare.Data.Doctor/Details/5

        public ActionResult Details(int id = 0)
        {
            Humancare.Data.Doctor doctor = doctorRepository.getDoctor(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        //
        // GET: /Humancare.Data.Doctor/Humancare.Data.Doctor/Create

        public ActionResult Create()
        {
            ViewBag.SpecializationList = sr.getSpecializations();
            Humancare.Data.Doctor doctor=new Humancare.Data.Doctor();
            List<Specialization> Specializations = new List<Specialization>();
            //doctor.Specializations = specializations;
            List<String> SpecializationsString = new List<String>();

            ViewBag.SpecializationsString = SpecializationsString;
            ViewBag.Specializations = Specializations;
           // doctor.Specializations.Add = specializations.AsEnumerable();
            return View(doctor);
        }

        //
        // POST: /Humancare.Data.Doctor/Humancare.Data.Doctor/Create

        [HttpPost]
        public ActionResult Create(Humancare.Data.Doctor doctor, FormCollection c, List<int> Specializations)
        {
            
            try
            {
               //doctor.Specializations.Concat(doctor.SelectedSpecializations);

                //find selected specialization
                foreach (int s in Specializations)
                {
                    Specialization sp = doctorRepository.getSpecialization(s);
                    //detach object
                    
                    //entities.Detach(sp);
                    doctor.Specializations.Add(sp);
                   
                }

               

              

                doctorRepository.save(doctor);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof(DbEntityValidationException))
                {
                    if (this.HttpContext.IsDebuggingEnabled)
                    {
                        ModelState.AddModelError(string.Empty, e.ToString());
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Some Technical error Happened");

                    }
                }
                ViewBag.SpecializationList = sr.getSpecializations();
               
                //doctor.Specializations = specializations;
                List<String> SpecializationsString = new List<String>();

                ViewBag.SpecializationsString = SpecializationsString;
                ViewBag.Specializations = Specializations;
                // doctor.Specializations.Add = specializations.AsEnumerable();
                return View(doctor);
            }
        }

        //
        // GET: /Humancare.Data.Doctor/Humancare.Data.Doctor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Humancare.Data.Doctor doctor = doctorRepository.getDoctor(id);


            List<int> SpecializationsString = new List<int>();

            ViewBag.SpecializationsString = SpecializationsString;
            
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        //
        // POST: /Humancare.Data.Doctor/Humancare.Data.Doctor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            

                // TODO: Add update logic here
                Humancare.Data.Doctor doctor = doctorRepository.getDoctor(id);
                UpdateModel(doctor);
                


                doctorRepository.save();
                return RedirectToAction("Index");
            
         
        }

        //
        // GET: /Humancare.Data.Doctor/Humancare.Data.Doctor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Humancare.Data.Doctor doctor = doctorRepository.getDoctor(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        //
        // POST: /Humancare.Data.Doctor/Humancare.Data.Doctor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            doctorRepository.delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
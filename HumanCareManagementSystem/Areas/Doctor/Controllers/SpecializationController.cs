using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using Humancare.Data;
using HumanCare.BLL.repositories;


namespace HumanCarePresentationLayer.Areas.Doctor.Controllers
{
    public class SpecializationController : Controller
    {
        //
        // GET: /Doctor/Specialization/

        SpecializationRepository specializationBLL = new SpecializationRepository();
        HealthCareNewEntities entities = new HealthCareNewEntities();
        public ActionResult Index()
        {
            IEnumerable<Specialization> specilizations = specializationBLL.getSpecializations();
            return View(specilizations);
        }

        //
        // GET: /Doctor/Specialization/Details/5

        public ActionResult Details(int id)
        {
            Specialization specilization = specializationBLL.getSpecialization(id);
            return View(specilization);
        }

        //
        // GET: /Doctor/Specialization/Create

        public ActionResult Create()
        {
            Specialization s = new Specialization();

            return View(s);
        }

        //
        // POST: /Doctor/Specialization/Create

        [HttpPost]
        public ActionResult Create(Specialization specilization, FormCollection collection)
        {
            try
            {
                
                specializationBLL.save(specilization);
            
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                if (e.GetType() != typeof(DbEntityValidationException))
                {
                    if (this.HttpContext.IsDebuggingEnabled)
                    {
                        ModelState.AddModelError(string.Empty, e.ToString());
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,"Some Technical error Happened");

                    }
                }
                return View();
            }
        }

        //
        // GET: /Doctor/Specialization/Edit/5

        public ActionResult Edit(int id)
        {
           

            return View(specializationBLL.getSpecialization(id));
        }

        //
        // POST: /Doctor/Specialization/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Specialization s = specializationBLL.getSpecialization(id);
                UpdateModel(s);
                specializationBLL.save();
                return RedirectToAction("Index");
            }
            catch(Exception e)
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
                return View();
            }
        }

        //
        // GET: /Doctor/Specialization/Delete/5

        public ActionResult Delete(int id)
        {

            return View(specializationBLL.getSpecialization(id));
        }

        //
        // POST: /Doctor/Specialization/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Specialization specialization)
        {
            try
            {
                specializationBLL.delete(id);
                

                return RedirectToAction("Index");
            }
            catch(Exception e)
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
                return View();
            }
        }
    }
}

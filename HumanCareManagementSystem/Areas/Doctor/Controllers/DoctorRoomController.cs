using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Humancare.Data;
using HumanCare.BLL;

namespace HumanCarePresentationLayer.Areas.Doctor.Controllers
{
    public class DoctorRoomController : Controller
    {
        private HealthCareNewEntities db = new HealthCareNewEntities();
        private DoctorAssignRoom doctorAssignment = new DoctorAssignRoom();
        //
        // GET: /Doctor/DoctorRoom/

        public ActionResult Index()
        {
            return View(db.Doctor_Room.ToList());
        }

        //
        // GET: /Doctor/DoctorRoom/Details/5

        public ActionResult Details(int id = 0)
        {
            Doctor_Room doctor_room = db.Doctor_Room.Single(d => d.id == id);
            if (doctor_room == null)
            {
                return HttpNotFound();
            }
            return View(doctor_room);
        }

        //
        // GET: /Doctor/DoctorRoom/Create

        public ActionResult Create()
        {
            ViewBag.DoctorList = db.Doctors.ToList();
            ViewBag.SelectedDoctorId = 1;
            ViewBag.RoomList = db.Rooms.ToList();
            ViewBag.SelectedRoomId = 1;
            return View();
        }

        //
        // POST: /Doctor/DoctorRoom/Create

        [HttpPost]
        public ActionResult Create(Doctor_Room doctor_room)
        {
            if (ModelState.IsValid)
            {
                string msg=doctorAssignment.AssignRoom(doctor_room);
                if (msg == string.Empty)
                {

                    
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.errorMessage = msg;
                    ViewBag.DoctorList = db.Doctors.ToList();
                    ViewBag.SelectedDoctorId = 1;
                    ViewBag.RoomList = db.Rooms.ToList();
                    ViewBag.SelectedRoomId = 1;
                    if (Request.IsAjaxRequest())
                    {
                        return PartialView(doctor_room);
                    }
                    else
                    return View(doctor_room);
                }
            }

            return View(doctor_room);
        }

        //
        // GET: /Doctor/DoctorRoom/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Doctor_Room doctor_room = db.Doctor_Room.Single(d => d.id == id);
            ViewBag.DoctorList = db.Doctors.ToList();
            
            ViewBag.RoomList = db.Rooms.ToList();
            
            if (doctor_room == null)
            {
                return HttpNotFound();
            }
            return View(doctor_room);
        }

        //
        // POST: /Doctor/DoctorRoom/Edit/5

        [HttpPost]
        public ActionResult Edit(Doctor_Room doctor_room)
        {
            if (ModelState.IsValid)
            {
                db.Doctor_Room.Attach(doctor_room);
                db.ObjectStateManager.ChangeObjectState(doctor_room, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor_room);
        }

        //
        // GET: /Doctor/DoctorRoom/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Doctor_Room doctor_room = db.Doctor_Room.Single(d => d.id == id);
            if (doctor_room == null)
            {
                return HttpNotFound();
            }
            return View(doctor_room);
        }

        //
        // POST: /Doctor/DoctorRoom/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor_Room doctor_room = db.Doctor_Room.Single(d => d.id == id);
            db.Doctor_Room.DeleteObject(doctor_room);
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
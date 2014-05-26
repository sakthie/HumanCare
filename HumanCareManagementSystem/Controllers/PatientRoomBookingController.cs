using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Humancare.Data;
using HumanCare.BLL;

namespace HumanCarePresentationLayer.Controllers
{
    public class PatientRoomBookingController : Controller
    {
        //
        // GET: /PatientRoom/

        //PatientRoomBookingController patroomBooking = new PatientRoomBookingController();

        public ActionResult RoomAvailability()
        {
            return View();
        }

        public ActionResult RoomBooking()
        {
            return View();
        }

        public ActionResult RoomModification()
        {
            return View();
        }

        public ActionResult PatientInRoom()
        {
            /*var allpatientinroom = from pr in Patient_Room 
                                   join p in Patient on pr.patientid equals p.patientid 
                                   join r in Room on r.roomid equals pr.roomid 
                                   select p; */
            return View();
        }

        public ActionResult Others()
        {
            return View();
        }

    }
}

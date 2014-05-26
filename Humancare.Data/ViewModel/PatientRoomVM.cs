using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Humancare.Data.ViewModel
{
   public class PatientRoomVM
    {
        public List<Patient> patientlist { get; set; }
        public List<Patient_Room> patientroomlist { get; set; }
        public List<Room> roomlist { get; set; }
    }
}

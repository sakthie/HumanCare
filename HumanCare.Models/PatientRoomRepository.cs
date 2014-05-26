using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Humancare.Data;

namespace HumanCare.BLL
{
   public class PatientRoomRepository
    {
       private HealthCareNewEntities db = new HealthCareNewEntities();

        public IEnumerable<Patient> getallPatientroom()
        {
            return db.Patients;
        }
    }
}

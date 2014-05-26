using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humancare.Data;

namespace HumanCare.BLL
{
    public class PatientRepository
    {
        HealthCareNewEntities db = new HealthCareNewEntities();
        public IEnumerable<Patient> getallPatient()
        {
            return db.Patients;
        }
    }
}

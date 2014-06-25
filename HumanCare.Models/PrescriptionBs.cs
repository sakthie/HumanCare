using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Humancare.Data;

namespace HumanCare.BLL
{
    public class PrescriptionBs
    {
        HealthCareNewEntities db = new HealthCareNewEntities();
        public bool AddNewPrescription(Patient_Prescription pp)
        {
            db.Patient_Prescription.AddObject(pp);
            db.SaveChanges();
            return true;
        } 

    }

}
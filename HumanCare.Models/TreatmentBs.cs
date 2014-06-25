using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Humancare.Data;

namespace HumanCare.BLL
{
    public class TreatmentBs
    {
        HealthCareNewEntities db = new HealthCareNewEntities();
        public IEnumerable<Patient_Treatment> getallPatient()
        {
            
            return db.Patient_Treatment;
        }
public bool addNewTreatement(Patient_Treatment pt)
        {        

            db.Patient_Treatment.AddObject(pt);
            db.SaveChanges();
            return true;
        }

public Patient_Treatment getItemOfTreatment(int id) {
    Patient_Treatment op = db.Patient_Treatment.First(x => x.treatmentId == id);
    return op;
}
public Patient_Treatment editTreatment(Patient_Treatment p)
{
   Patient_Treatment op = db.Patient_Treatment.First(x => x.treatmentId == p.treatmentId);
   op.description = p.description;
   op.doctorId = p.doctorId;
   op.endDate = p.endDate;
   op.patientId = p.patientId;
   op.prescriptionId = p.prescriptionId;
   op.roomId = p.roomId;
   op.startDate = p.startDate;
   db.SaveChanges();
   return op;
}
    }


   

}

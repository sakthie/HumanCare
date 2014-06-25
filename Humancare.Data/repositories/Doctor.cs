using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humancare.Data;

namespace HumanCare.BLL.repositories
{
    public class DoctorRepository
    {
        HealthCareNewEntities entities = new HealthCareNewEntities();

        public Doctor getDoctor(int id)
        {
          
            return entities.Doctors.Where(e => e.id == id).SingleOrDefault();
        }

        public void delete(int id)
        {
            Doctor d = getDoctor(id);
            entities.Doctors.DeleteObject(d);
            entities.SaveChanges();
        }

       

        public void save(Doctor d)
        {
            entities.Doctors.AddObject(d);
            entities.SaveChanges();
        }

        public void save()
        {
           
            entities.SaveChanges();
        }

        public IEnumerable<Doctor> getDoctors()
        {
            return entities.Doctors;
        }

        public Specialization getSpecialization(int id)
        {
            Specialization specialization = entities.Specializations.Where(s => s.id == id).SingleOrDefault();
            return specialization;
        }
    }
}

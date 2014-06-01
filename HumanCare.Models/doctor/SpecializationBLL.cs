using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humancare.Data;
namespace HumanCare.BLL.doctor
{
    public class SpecializationBLL
    {
        HealthCareNewEntities entities = new HealthCareNewEntities();

        public Specialization getSpecialization(int id)
        {
            return entities.Specializations.Where(e=>e.id==id).SingleOrDefault();
        }

        public void delete(int id)
        {
            Specialization s=getSpecialization(id);
            entities.Specializations.DeleteObject(s);
            entities.SaveChanges();
        }

        public void save(Specialization s)
        {
            entities.Specializations.AddObject(s);
            entities.SaveChanges();
        }

        public IEnumerable<Specialization> getSpecializations()
        {
            return entities.Specializations;
        }
    }
}

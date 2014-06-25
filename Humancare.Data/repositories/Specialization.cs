using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humancare.Data;
namespace HumanCare.BLL.repositories
{
    public class SpecializationRepository
    {
        HealthCareNewEntities entities = new HealthCareNewEntities();

       

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

        public void save()
        {
          
            entities.SaveChanges();
        }

        public IEnumerable<Specialization> getSpecializations()
        {
            return entities.Specializations;
        }

        public Specialization getSpecialization(int id)
        {
            Specialization specialization = entities.Specializations.Where(s => s.id == id).SingleOrDefault();
            return specialization;
        }
    }
}

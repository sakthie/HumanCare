using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Humancare.Data.repositories
{

    /// <summary>
    /// author: Mani
    /// Description: 
    /// Bill Repository is used for all the bill related db activities from the entities.
    /// It could have been directly done from the controller itself. However, this structure creates a more layered approach, which can be easily 
    /// modified in case of any changes or additional functionality.
    /// </summary>
   
    public class BillRepository
    {
        HealthCareNewEntities entities = new HealthCareNewEntities();


        //To retrieve a bill from entities
        public Bill getBill(int id)
        {
            return entities.Bills.Where(e => e.Id == id).SingleOrDefault();
        }

        //To delete a bill from entities
        public void delete(int id)
        {
            Bill b = getBill(id);
            entities.Bills.DeleteObject(b);
            entities.SaveChanges();
        }

        //To save a bill from entities
        public void save(Bill b)
        {
            entities.Bills.AddObject(b);
            entities.SaveChanges();
        }

        public void save()
        {

            entities.SaveChanges();
        }

        public IEnumerable<Bill> getBills()
        {
            return entities.Bills;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humancare.Data;
using System.Data.Entity;
using System.Transactions;

namespace HumanCare.BLL
{

    /// <summary>
    /// Author: Mani
    /// 
    /// Description:
    /// The Billing process is responsible for creating a bill and saving it to the data base.
    /// It performs few business logic rules and ensures data persistence by using the transaction scope
    /// </summary>
    public class ManagerBill
    {
        HealthCareNewEntities entities = new HealthCareNewEntities();

        public void GenerateBill(Bill bill)
        {
            
            bill.ErrorMessage = String.Empty;
            bill.amount = 0;
            bill.isValid = true;
            Patient_Treatment pt = entities.Patient_Treatment.FirstOrDefault(x => x.treatmentId == bill.treatmentId);

            //Business Logic to save the bill

            if ((pt == null || pt.Patient == null) && bill.isValid)
            {
                bill.isValid = false;
                bill.ErrorMessage = "Patient Could not be found or patient treatment could not be found " + Environment.NewLine;
            }

            if (bill.isValid && ((TimeSpan)(pt.endDate-pt.startDate)).TotalDays<0)
            {
                bill.isValid = false;
                bill.ErrorMessage = "Patient has been filed with an invalid treatment date. Please rectify with the Treatments department" + Environment.NewLine;
            }

            if(bill.isValid)
            bill.amount = Convert.ToDecimal(pt.Doctor.costPerTreatment);

            if (bill.isValid && bill.amount <= 0)
            {
                bill.isValid = false;
                bill.ErrorMessage = bill.ErrorMessage + Environment.NewLine + "Amount not being charged. Please check with the doctor consultation charge" + Environment.NewLine;
            }
            if (entities.Bills.SingleOrDefault(x=> x.treatmentId == bill.treatmentId) != null)
            {
                bill.isValid = false;
                bill.ErrorMessage = bill.ErrorMessage + Environment.NewLine + "Amount already charged. Please cross check" + Environment.NewLine;
            }
            try
            {

                using (TransactionScope ts = new TransactionScope())
                {
                    if (bill.isValid)
                    {
                    if (pt.isAdmitted == 1)
                    {

                        Patient_Room pm = entities.Patient_Room.SingleOrDefault(x => x.treatmentId == bill.treatmentId);

                        bill.amount = bill.amount + Convert.ToDecimal(((TimeSpan)(pm.toDate-pm.fromDate)).Days * pm.Room.Room_Type.costPerDay);

                        if (pm.Room.vacancy == "1")
                            roomVacated(pm.Room);

                    }
                        bill.dateOfBill = DateTime.Now;
                        entities.AddToBills(bill);
                        entities.SaveChanges();
                        ts.Complete();
                    }
                    else
                    {
                        bill.ErrorMessage = bill.ErrorMessage + Environment.NewLine + "Error while saving the bill" + Environment.NewLine;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                bill.ErrorMessage = ex.Message + Environment.NewLine;
            }

        }

        // vacate the room
        private void roomVacated(Room rm)
        {
            rm.vacancy = "0";
            entities.SaveChanges();

        }
    }
}

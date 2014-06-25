using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humancare.Data;
using System.Transactions;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace HumanCare.BLL
{
    public class DoctorAssignRoom
    {
        HealthCareNewEntities entities = new HealthCareNewEntities();

        public string AssignRoom(Doctor_Room doctorRoom)
        {
            doctorRoom.isValid = true;
            doctorRoom.errorMessage = string.Empty;

            doctorRoom.Validate();

            if (doctorRoom.isValid)
            {
                //insert slot and save insert row in doctor room table
                
                
                try
                {
                    using(TransactionScope trans = new TransactionScope())
                    {
                        
                        DateTime startDateTime = doctorRoom.startDateTime.Value;
                        DateTime endDateTime = doctorRoom.endDateTime.Value;

                        foreach (DateTime day in DoctorAssignRoom.EachDay(startDateTime, endDateTime))
                        {
                            Doctor_AppntSlot doctorAppointmentSlot = new Doctor_AppntSlot();
                            doctorAppointmentSlot.doctorId = doctorRoom.doctorId;
                            doctorAppointmentSlot.appntDate = day;
                            doctorAppointmentSlot.slotAvaliable = 15;
                            doctorAppointmentSlot.slotAllocated = 0;
                            doctorAppointmentSlot.timePerSlot = 15;
                            entities.Doctor_AppntSlot.AddObject(doctorAppointmentSlot);
                            entities.SaveChanges();
                        }

                        //insert doctor room slot
                        entities.Doctor_Room.AddObject(doctorRoom);
                        entities.SaveChanges();
                        trans.Complete();
                        
                    }
                }

                catch (DbUpdateConcurrencyException ex)
                {
                   
                    return "The record you attempted to Update "
                        + "was modified by another user after you got the original value. The "
                        + "Update operation was canceled and the current values in the database "
                        + "have been displayed. If you still want to edit this record, click "
                        + "the Save button again. ";
                    
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                    return "Unable to save changes. Try again, and if the problem persists contact your system administrator.";
                }

            }
            else
            {
                return doctorRoom.errorMessage;
            }


           
            return string.Empty;
        }


        public static  IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

    }


}

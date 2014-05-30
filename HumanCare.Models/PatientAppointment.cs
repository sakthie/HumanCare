using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humancare.Data;
using System.Globalization;
using System.Security.Permissions;


namespace HumanCare.BLL
{
    //[PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
    //[PrincipalPermission(SecurityAction.Demand, Role = "Patient")]
   
    public class PatientAppointment
    {
        Patient_Appointment appointobj = new Patient_Appointment();
        
        public string createpatientappointment(string patientid, String appntid, string dateid, string doctorid, DateTime start, DateTime end, string prescid)
        {
            using (HealthCareNewEntities db = new HealthCareNewEntities())
            {
                try
                {
                    var patientIncrementid = from cs in db.Patients select cs.patientId;
                    var max_Id = (from a in db.Patients select a.patientId.Substring(3, 5)).Max();
                    patientid = "PAT" + max_Id.ToString();
                    appntid = ReturnAppointmentIncrementID();

                    var appointmentDateID = (from c in db.Doctor_AppntSlot where c.doctorId == doctorid select c.dateId).SingleOrDefault();
                    appointobj.patientId = patientid;
                    appointobj.appntId = appntid;
                    appointobj.dateId = appointmentDateID;
                    appointobj.doctorId = doctorid;
                    appointobj.startTime = start;
                    appointobj.endTime = end;
                    appointobj.prescriptionId = prescid;
                    appointobj.description = "patient";
                    appointobj.upcomingPast = "Y";
                    db.Patient_Appointment.AddObject(appointobj);
                    db.SaveChanges();
                    return patientid;
                }
                catch (Exception ex)
                {
                    return patientid;
                }
            }

        }

        public string ReturnPatientIncrementID()
        {
            using (HealthCareNewEntities db = new HealthCareNewEntities())
            {
                var patientIncrementid = from cs in db.Patients select cs.patientId;
                if (patientIncrementid.Count().Equals(0))
                {
                    appointobj.patientId = "PAT" + 100;
                }
                else
                {
                    var max_Id = (from a in db.Patients select a.patientId.Substring(3, 5)).Max();
                    appointobj.patientId = "PAT" + (Convert.ToInt32(max_Id) + 1).ToString();
                }
            }
            return appointobj.patientId;
        }

        public string ReturnAppointmentIncrementID()
        {
            using (HealthCareNewEntities db = new HealthCareNewEntities())
            {
                var AppointmentIncrementid = from cs in db.Patient_Appointment select cs.appntId;
                if (AppointmentIncrementid.Count().Equals(0))
                {
                    appointobj.appntId = "APP" + 100;
                }
                else
                {
                    var max_Id = (from a in db.Patient_Appointment select a.appntId.Substring(3, 5)).Max();
                    appointobj.appntId = "APP" + (Convert.ToInt32(max_Id) + 1).ToString();
                }
            }
            return appointobj.appntId;
        }

        public string CreatePatient(string patientID, string name, int phone, string email, string gender, DateTime DOB, string nationality, string icNUM, string street, string area, string country, int postalCode)
        {
            try
            {
                using (HealthCareNewEntities db = new HealthCareNewEntities())
                {
                    patientID = ReturnPatientIncrementID();
                    Patient pat = new Patient();
                    pat.patientId = patientID;
                    pat.name = name;
                    pat.phone = phone;
                    pat.email = email;
                    pat.gender = gender;
                    pat.dob = DOB;
                    pat.nationality = nationality;
                    pat.icNum = icNUM;
                    pat.street = street;
                    pat.area = area;
                    pat.country = country;
                    pat.postalCode = postalCode;
                    db.AddToPatients(pat);
                    db.SaveChanges();
                    return patientID;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string updateData(string patientid, String appntid, string dateid, string doctoid, string prescid, DateTime start, DateTime end)
        {
            string status = "";
            try
            {
                using (HealthCareNewEntities db = new HealthCareNewEntities())
                {
                    var appointobj = (from r in db.Patient_Appointment.Where(w => w.patientId.Equals(patientid)) select r).FirstOrDefault();
                    appointobj.appntId = appntid;
                    appointobj.dateId = dateid;
                    appointobj.doctorId = doctoid;
                    appointobj.patientId = patientid;
                    appointobj.prescriptionId = prescid;
                    appointobj.startTime = start;
                    appointobj.endTime = end;
                    db.Patient_Appointment.AddObject(appointobj);
                    db.SaveChanges();
                    DoctorslotupdateData(dateid, doctoid);
                    status = appointobj.patientId;
                }
                return status;
            }
            catch
            {
                return status;
            }
        }

        public string DoctorslotupdateData(string dateid, string _doctorid)
        {
            string status = "";
            try
            {

                using (HealthCareNewEntities db = new HealthCareNewEntities())
                {
                    var appointobj = (from r in db.Doctor_AppntSlot.Where(w => w.doctorId == _doctorid) select r).FirstOrDefault();
                    appointobj.slotAllocated = appointobj.slotAllocated + 1;
                    appointobj.slotAvaliable = appointobj.slotAvaliable - 1;
                    db.SaveChanges();

                    status = appointobj.doctorId;
                }
                return status;
            }
            catch
            {
                return status;
            }
        }



        public int deleteData(string patientid)
        {
            try
            {
                int status = 0;
                using (HealthCareNewEntities db = new HealthCareNewEntities())
                {
                    var obj = (from r in db.Patient_Appointment.Where(w => w.patientId.Equals(patientid)) select r).FirstOrDefault();
                    db.Patient_Appointment.DeleteObject(obj);
                    db.SaveChanges();

                }
                return status;
            }
            catch
            {
                return -1;
            }
        }



        public List<Patient_Appointment> SelectData(int patientid)
        {
            try
            {
                using (HealthCareNewEntities db = new HealthCareNewEntities())
                {
                    List<Patient_Appointment> obj = (from r in db.Patient_Appointment.Where(w => w.patientId.Equals(patientid)) select r).ToList();
                    return obj;

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Patient_Appointment> SelectAllData()
        {
            try
            {
                using (HealthCareNewEntities context = new HealthCareNewEntities())
                {
                    List<Patient_Appointment> Appointmentobj = (from r in context.Patient_Appointment select r).ToList();
                    //var obj = Appointmentobj.Select((j, l) => new { j.patientId, j.description, index = l + 1  }).ToList();
                    return Appointmentobj;

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Doctor> SelectAllDoctorData()
        {
            try
            {
                using (HealthCareNewEntities context = new HealthCareNewEntities())
                {
                    List<Doctor> Doctorobj = (from r in context.Doctors select r).ToList();
                    return Doctorobj;

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Specialization> SelectAllSpecializationData()
        {
            try
            {
                using (HealthCareNewEntities context = new HealthCareNewEntities())
                {
                    List<Specialization> Specializeobj = (from r in context.Specializations select r).ToList();
                    //var obj = Appointmentobj.Select((j, l) => new { j.patientId, j.description, index = l + 1  }).ToList();
                    return Specializeobj;

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Nationality> SelectAllNationalityData()
        {
            try
            {
                using (HealthCareNewEntities context = new HealthCareNewEntities())
                {
                    List<Nationality> nationalityObj = (from r in context.Nationalities select r).ToList();
                    return nationalityObj;

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        static IEnumerable<DateTime> AllDatesBetween(DateTime start, DateTime end)
        {
            for (var day = start.Date; day <= end; day = day.AddDays(1))
                yield return day;
        }

        public List<string> returnPreferredDates()
        {
            string dateInString = DateTime.Now.ToString();

            DateTime startDate = DateTime.Parse(dateInString);
            DateTime expiryDate = startDate.AddDays(30);
            string monthName = startDate.ToString("MMM", CultureInfo.InvariantCulture);
            var calculatedDates =
    new List<string>
    (
        AllDatesBetween
        (
            startDate,
            expiryDate
        ).Select(d => d.ToString("MMM d yyyy"))
    );


            return calculatedDates;
        }


        public List<Doctor> SelectAllDoctor()
        {
            try
            {
                using (HealthCareNewEntities context = new HealthCareNewEntities())
                {
                    List<Doctor> doctorObj = (from r in context.Doctors select r).ToList();
                    return doctorObj;

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //public List<Doctor_AppntSlot> SelectPreferredTimeSlot()
        //{
        //    try
        //    {
        //        using (HealthCareNewEntities context = new HealthCareNewEntities())
        //        {
        //            List<Doctor_AppntSlot> timeSlotObj = (from r in context.Doctor_AppntSlot select new Doctor_AppntSlot { workStartTime = r.workStartTime, workEndTime = r.workEndTime }).ToList();

        //            return timeSlotObj;

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public List<Doctor_AppntSlot> GetProducts()
        //{
        //    using (HealthCareNewEntities context = new HealthCareNewEntities())
        //            {
        //                return (from p in context.Doctor_AppntSlot

        //                        select new Doctor_AppntSlot1 { workStartTime = p.workStartTime }).ToList();
        //}
        //}


        //public List<DateTime> MergeIntoLargerSlots(List<DateTime> slots, int minutes)
        //{
        //    int count = minutes / 30;
        //    List<DateTime> retVal = new List<DateTime>();
        //    foreach (DateTime slot in slots)
        //    {
        //        DateTime end = slot.AddMinutes(minutes);
        //        if (slots.Where(x => x >= slot && x < end).Count() == count)
        //        {
        //            retVal.Add(slot);
        //        }
        //    }
        //    return retVal;
        //}
    }

    //public class DateTime
    //{
    //    public DateTime workStartTime { get; set; }
    //    public DateTime workEndTime { get; set; }
    //    // Other field you may need from the Product entity
    //}

}

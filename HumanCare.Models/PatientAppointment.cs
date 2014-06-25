using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humancare.Data;
using System.Globalization;
using Humancare.Data.ViewModel;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace HumanCare.BLL
{
    public class PatientAppointment
    {
        Patient_Appointment appointObj = new Patient_Appointment();
        String appntDateFormat = "MMM d yyyy";

        public int createpatientappointment(int patientId, int appntId, int dateId, int doctorId, int prescId, DateTime appDate)
        {
            using (HealthCareNewEntities entities = new HealthCareNewEntities())
            {
                try
                {
                    appntId = (from a in entities.Patients select a.patientId).Max() + 1;
                    var appointmentDateID = (from c in entities.Doctor_AppntSlot where c.doctorId == doctorId && c.appntDate == appDate select c.dateId).FirstOrDefault();
                    appointObj.patientId = patientId;
                    appointObj.appntId = appntId;
                    appointObj.dateId = appointmentDateID;
                    appointObj.doctorId = doctorId;
                   // appointObj.prescriptionId = prescId;
                    appointObj.description = "patient";
                    appointObj.upcomingPast = "Y";
                    entities.Patient_Appointment.AddObject(appointObj);
                    entities.SaveChanges();
                    return patientId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public int CreatePatient(string name, int phone, string email, string gender, DateTime DOB, string nationality, string icNUM, string street, string area, string country, int postalCode)
        {
            try
            {
                using (HealthCareNewEntities entities = new HealthCareNewEntities())
                {
                    Patient pat = new Patient();
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
                    entities.AddToPatients(pat);
                    entities.SaveChanges();
                    return 1;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateData(int patientId, int appntId, int dateId, int doctorId, int prescId, DateTime start, DateTime end)
        {
            int status = 0;
            try
            {
                using (HealthCareNewEntities entities = new HealthCareNewEntities())
                {
                    var appointObj = (from r in entities.Patient_Appointment.Where(w => w.patientId.Equals(patientId)) select r).FirstOrDefault();
                    appointObj.appntId = appntId;
                    appointObj.dateId = dateId;
                    appointObj.doctorId = doctorId;
                    appointObj.patientId = patientId;
                    //appointObj.prescriptionId = prescId;
                    entities.Patient_Appointment.AddObject(appointObj);
                    entities.SaveChanges();
                    DoctorslotupdateData(dateId, doctorId);
                    status = appointObj.patientId;
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DoctorslotupdateData(int dateId, int doctorId)
        {
            int status = 0;
            try
            {

                using (HealthCareNewEntities entities = new HealthCareNewEntities())
                {
                    var appointObj = (from r in entities.Doctor_AppntSlot.Where(w => w.doctorId == doctorId) select r).FirstOrDefault();
                    appointObj.slotAllocated = appointObj.slotAllocated + 1;
                    appointObj.slotAvaliable = appointObj.slotAvaliable - 1;
                    entities.SaveChanges();

                    status = appointObj.doctorId;
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public int deleteData(string patientId)
        {
            try
            {
                int status = 0;
                using (HealthCareNewEntities entities = new HealthCareNewEntities())
                {
                    var patObj = (from r in entities.Patient_Appointment.Where(w => w.patientId.Equals(patientId)) select r).FirstOrDefault();
                    entities.Patient_Appointment.DeleteObject(patObj);
                    entities.SaveChanges();

                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<Patient_Appointment> SelectData(int patientId)
        {
            try
            {
                using (HealthCareNewEntities entities = new HealthCareNewEntities())
                {
                    List<Patient_Appointment> patAppointObj = (from r in entities.Patient_Appointment.Where(w => w.patientId.Equals(patientId)) select r).ToList();
                    return patAppointObj;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Patient_Appointment> SelectAllData()
        {
            try
            {
                using (HealthCareNewEntities Entities = new HealthCareNewEntities())
                {
                    List<Patient_Appointment> appointmentObj = (from r in Entities.Patient_Appointment select r).ToList();
                    return appointmentObj;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Doctor> SelectAllDoctorData()
        {
            try
            {
                using (HealthCareNewEntities Entities = new HealthCareNewEntities())
                {
                    List<Doctor> doctorObj = (from r in Entities.Doctors select r).ToList();
                    return doctorObj;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Specialization> SelectAllSpecializationData()
        {
            try
            {
                using (HealthCareNewEntities Entities = new HealthCareNewEntities())
                {
                    List<Specialization> specializeObj = (from r in Entities.Specializations select r).ToList();
                    return specializeObj;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Doctor> SelectDoctorBasedSpec(int specId)
        {
            try
            {
                using (HealthCareNewEntities context = new HealthCareNewEntities())
                {
                    List<Specialization> spec = (from sa in context.Specializations where sa.id == specId select sa).ToList();
                    List<Doctor> docs = spec[0].Doctors.ToList();

                    return docs;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Slot> SelectAppointmentSlot(String dateString)
        {
            try
            {
                String[] dateFormat = { appntDateFormat };
                DateTime dateAppnt = DateTime.ParseExact(dateString, dateFormat, new CultureInfo("en-US"), DateTimeStyles.None);
                using (HealthCareNewEntities context = new HealthCareNewEntities())
                {
                    List<Slot> onj = (from s in context.Slots
                                      where
                                      !
                                      (from p in context.Patient_Appointment
                                       where
                                           (from d in context.Doctor_AppntSlot
                                            where (d.appntDate.Equals(dateAppnt))
                                            select
                                                d.dateId
                                           ).Contains(p.dateId)
                                       select p.slotNo).Contains(s.slotNo)
                                      select s).ToList();
                    for (int itr = 0; itr < onj.Count; itr++)
                    {
                        Slot s = onj[itr];
                        s.startTime = s.startTime + " - " + s.endTime;
                        onj[itr] = s;
                    }
                    return onj;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<String> returnDatesBasedDoctor(int docId)
        {
            try
            {
                using (HealthCareNewEntities context = new HealthCareNewEntities())
                {
                    List<DateTime> obj = (from Doctor_AppntSlot in context.Doctor_AppntSlot
                                          where
                                            Doctor_AppntSlot.doctorId == docId
                                          select Doctor_AppntSlot.appntDate).ToList();
                    List<String> dateObj = new List<String>();
                    for (int itr = 0; itr < obj.Count; itr++)
                    {
                        dateObj.Add(obj[itr].ToString(appntDateFormat));
                    }
                    return dateObj;

                }

            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }
        static IEnumerable<DateTime> AllDatesBetween(DateTime start, DateTime end)
        {

            for (var day = start.Date; day <= end; day = day.AddDays(1))
                yield return day;

        }

        public List<string> returnPreferredDates()
        {
            try
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
            ).Select(d => d.ToString(appntDateFormat))
        );


                return calculatedDates;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Doctor> SelectAllDoctor()
        {
            try
            {
                using (HealthCareNewEntities Entities = new HealthCareNewEntities())
                {
                    List<Doctor> doctorObj = (from r in Entities.Doctors select r).ToList();
                    return doctorObj;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Patient> SelectPatientDetails(string icNum, string email, int phone)
        {
            try
            {
                using (HealthCareNewEntities Entities = new HealthCareNewEntities())
                {

                    List<Patient> patientObj;
                    if (icNum != string.Empty)
                    {
                        patientObj = (from r in Entities.Patients.Where(w => w.icNum.Equals(icNum)) select r).ToList();
                    }
                    else if (email != string.Empty)
                    {
                        patientObj = (from r in Entities.Patients.Where(w => w.email.Equals(email)) select r).ToList();
                    }
                    else
                    {
                        patientObj = (from r in Entities.Patients.Where(w => w.phone.Equals(phone)) select r).ToList();
                    }
                    return patientObj;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Humancare.Data.ViewModel.PatientAppointment.patientapp> SelectPatientAppointmentforDoctor()
        {
            try
            {
                using (HealthCareNewEntities Entities = new HealthCareNewEntities())
                {

                    var patAppointment = (from b in Entities.Patient_Appointment
                                          from c in Entities.Doctor_AppntSlot
                                          from d in Entities.Slots
                                          from e in Entities.Doctors
                                          where
                                              b.doctorId == c.doctorId &&
                                              b.slotNo == d.slotNo &&
                                              b.doctorId == e.id &&
                                              b.dateId == c.dateId
                                          select new Humancare.Data.ViewModel.PatientAppointment.patientapp
                                          {
                                              name = b.Patient.name,
                                              gender = b.Patient.gender,
                                              appntId = b.appntId,
                                              appntDate = c.appntDate,
                                              startTime = d.startTime,
                                              endTime = d.endTime
                                          }).ToList();

                    return patAppointment;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SendEmailtoPatient(string patientName, string icNUm, DateTime DOB, string gender, int contactNumber, string emailID, string nationality, string speciality, string doctorName, string AppDate, string slot)
        {
            try
            {
                using (HealthCareNewEntities Entities = new HealthCareNewEntities())
                {
                    var patientID = (from r in Entities.Patients.Where(w => w.icNum == icNUm) select r).FirstOrDefault();
                    var appID = (from r in Entities.Patient_Appointment.Where(w => w.patientId == Convert.ToInt32(patientID)) select r).FirstOrDefault();
                    speciality = "Ortho";
                    slot = "08:00-08:30";
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("Humancaremail@gmail.com");
                    mail.To.Add(emailID);
                    mail.Subject = "Humancare Appointment Details";
                    mail.IsBodyHtml = true;
                    string MailBody = "";
                    MailBody = MailBody + "<body>";
                    MailBody = MailBody + "<table style='width: 100%;font-size:10px; font-family: Arial,Helvetica,sans-serif'>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>Appointment Request</B></td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>Hi " + patientName + "</B></td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'>This is to confirm receipt of your message. Our customer care executive will get back to you with the information you requested. Thank You.</td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>PATIENT ID :</B> " + patientID + " #26797</td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>APPOINTMENT ID :</B> " + appID + " #26797</td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>IC No :</B>" + icNUm + " </td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>Date of Birth :</B> " + DOB + "</td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>Gender :</B> " + gender + "</td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>Phone/Mobile :</B> " + contactNumber + "</td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>Email :</B> " + emailID + " </td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>Nationality :</B> " + nationality + " </td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>Speciality :</B> " + speciality + " </td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>Consulting Doctor :</B> " + doctorName + "</td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>Preferred Date :</B> " + AppDate + "</td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'><B>Preferred Time Slot :</B> " + slot + " </td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'>Regards,</td></tr>";
                    MailBody = MailBody + "<tr><td style='width:100%;text-align:left'>Healthcare</td></tr>";
                    MailBody = MailBody + "</table></body></html>";
                    mail.Body = MailBody;
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("Humancaremail@gmail.com", "Human@123");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    return "Success";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

}

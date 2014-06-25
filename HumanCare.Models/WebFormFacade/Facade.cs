using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using HumanCare.BLL.WebFormBLL;
using Humancare.Data.ViewModel;
using Humancare.Data;

namespace HumanCare.BLL.WebFormFacade
{
    public interface IPatientRegister
    {
        void createpatientappointment(int patientid, int dateid, int doctorid, int slotNo);
        List<Patient> SelectPatientDetails(string icNum, string email, int phone);
        string CreatePatient(string name, int phone, string email, string gender, DateTime DOB, string nationality, string icNUM, string street, string area, string country, int postalCode);
        List<Doctor> SelectDoctorBasedSpec(int specId);
        List<Slot> SelectAppointmentSlot(String dateString);
        List<Doctor_AppntSlot> returnDatesBasedDoctor(int docId);
        List<Nationality> SelectAllNationalityData();
        List<Doctor> SelectAllDoctor();
        IEnumerable<Humancare.Data.ViewModel.PatientAppointment.patientapp> SelectPatientAppointmentforDoctor();
        string SendEmailtoPatient(string patientName, string icNUm, DateTime DOB, string gender, int contactNumber, string emailID, string nationality, string speciality, string doctorName, string AppDate, string slot);
        List<Specialization> SelectAllSpecializationData();
        int returnPatientfromIC(string icNo);
        List<string> returnPreferredDates();

    }
    public class Facade : IPatientRegister
    {
        //PatientInRoomBLL patientinroombll;
        //RoomAvailabilityBLL roomavailababilitybll;
        //RoomBookingBLL roombookingbll;
        //RoomModificationBLL roommodificationbll;
        PatientAppointment appointment;

        public Facade()
        {
            //patientinroombll = new PatientInRoomBLL();
            //roomavailababilitybll = new RoomAvailabilityBLL();
            //roombookingbll = new RoomBookingBLL();
            //roommodificationbll = new RoomModificationBLL();
            appointment = new PatientAppointment();
        }

        //public IEnumerable<Patientinroommodel> patientinroomload()
        //{
        //    return patientinroombll.patientinroomload();
        //}

        //public List<Room_Type> patientroomavailabilityload()
        //{
        //    return roomavailababilitybll.patientroomavailabilityload();
        //}

        //public IEnumerable<Patientroomavailabilitymodel> patientroomavailability(int value)
        //{
        //    return roomavailababilitybll.patientroomavailability(value);
        //}

        //public int patientroomavailabilitycount(int value)
        //{
        //    return roomavailababilitybll.patientroomavailabilitycount(value);
        //}

        //public List<Patient> patientroombookingload()
        //{
        //    return roombookingbll.patientroombookingload();
        //}

        //public List<Room_Type> patientroombookingload_roomtype()
        //{
        //    return roombookingbll.patientroombookingload_roomtype();
        //}

        //public Patient patientroombooking_btnupload(int value)
        //{
        //    return roombookingbll.patientroombooking_btnupload(value);
        //}

        //public IEnumerable<Patientroombooking> patientroombooking_roomtypeDropDown(int value)
        //{
        //    return roombookingbll.patientroombooking_roomtypeDropDown(value);
        //}

        //public void savepatient_room(int roomid, int patientID, DateTime fromdate, int treatmentID)
        //{
        //    roombookingbll.savepatient_room(roomid, patientID, fromdate, treatmentID);
        //}

        //public void saveroom(int roomid)
        //{
        //    roombookingbll.saveroom(roomid);
        //}
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        //public Room roomnumberdropdown_SelectedIndexChanged(int value)
        //{
        //    return roommodificationbll.roomnumberdropdown_SelectedIndexChanged(value);
        //}

        //public IEnumerable<Patientroombooking> roomtypedropdown_SelectedIndexChanged(int value)
        //{
        //    return roommodificationbll.roomtypedropdown_SelectedIndexChanged(value);
        //}

        //public IEnumerable<Room_Type> roomtypedropdown_load()
        //{
        //    return roommodificationbll.roomtypedropdown_load();
        //}

        //public void addbtn_Click(int type, string roomno, Int32 phoneno, DateTime starttime, DateTime endtime, string location)
        //{
        //    roommodificationbll.addbtn_Click(type, roomno, phoneno, starttime, endtime, location);
        //}

        //public void editbtn_Click(int value, Int32 phoneNum, DateTime startdate, DateTime enddate)
        //{
        //    roommodificationbll.editbtn_Click(value, phoneNum, startdate, enddate);
        //}

        //public void suspendbtn_Click(int value)
        //{
        //    roommodificationbll.suspendbtn_Click(value);
        //}

        //public void suspendtypebtn_Click(int value)
        //{
        //    roommodificationbll.suspendtypebtn_Click(value);
        //}

        //public void edittypebtn_Click(int value, string description, double costPerDay)
        //{
        //    roommodificationbll.edittypebtn_Click(value, description, costPerDay);
        //}

        //public void addtypebtn_Click(string roomname, string description, double costPerDay)
        //{
        //    roommodificationbll.addtypebtn_Click(roomname, description, costPerDay);
        //}

        //public Room_Type roomtypedropdowntype_SelectedIndexChanged(int value)
        //{
        //    return roommodificationbll.roomtypedropdowntype_SelectedIndexChanged(value);
        //}

        /*********************** PATIENT APPOINTMENT ***************************/
        public void createpatientappointment(int patientid, int dateid, int doctorid, int slotNo)
        {
           
        }

        public List<Patient> SelectPatientDetails(string icNum, string email, int phone)
        {
            return appointment.SelectPatientDetails(icNum, email, phone);
        }

        public string CreatePatient(string name, int phone, string email, string gender, DateTime DOB, string nationality, string icNUM, string street, string area, string country, int postalCode)
        {
            return null;
        }

        public List<Doctor> SelectDoctorBasedSpec(int specId)
        {
            return appointment.SelectDoctorBasedSpec(specId);
        }
        public List<Slot> SelectAppointmentSlot(String dateString)
        {
            return appointment.SelectAppointmentSlot(dateString);
        }

        public List<Specialization> SelectAllSpecializationData()
        {
            return appointment.SelectAllSpecializationData();
        }
        public List<Doctor_AppntSlot> returnDatesBasedDoctor(int docId)
        {
            return null;
        }

        public List<Nationality> SelectAllNationalityData()
        {
            return appointment.SelectAllNationalityData();
        }

        public List<Doctor> SelectAllDoctor()
        {
            return appointment.SelectAllDoctor();
        }

        public IEnumerable<Humancare.Data.ViewModel.PatientAppointment.patientapp> SelectPatientAppointmentforDoctor()
        {
            return appointment.SelectPatientAppointmentforDoctor();
        }

        public string SendEmailtoPatient(string patientName, string icNUm, DateTime DOB, string gender, int contactNumber, string emailID, string nationality, string speciality, string doctorName, string AppDate, string slot)
        {
            return appointment.SendEmailtoPatient(patientName, icNUm, DOB, gender, contactNumber, emailID, nationality, speciality, doctorName, AppDate, slot);
        }

        public int returnPatientfromIC(string icNo)
        {
            return 1;
        }
        public List<string> returnPreferredDates()
        {
            return appointment.returnPreferredDates();
        }
    }
}

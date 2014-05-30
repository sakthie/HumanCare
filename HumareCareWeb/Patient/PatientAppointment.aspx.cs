using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HumanCare.BLL;
using System.Web.Security;
using System.Globalization;


namespace HumareCareWeb
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        PatientAppointment appointment = new PatientAppointment();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!User.Identity.IsAuthenticated)
                FormsAuthentication.RedirectToLoginPage();
             

            if (!IsPostBack)
                GetSpecialist();
            GetNationality();
            GetPrefferedDates();
            GetAllDoctor();
            //appointment.SelectPreferredTimeSlot();

            try
            {
                //DateTime oCurrentDate = DateTime.Now.AddDays(-1);
                //DateTime oCurrentDate = new DateTime(2014, 05, 25, 09, 00, 00);
                //DateTime oTimeSlot = new DateTime();
                //if (oCurrentDate.Minute > 30)
                //    oTimeSlot = new DateTime(oCurrentDate.Year, oCurrentDate.Month, oCurrentDate.Day, oCurrentDate.Hour, 30, 0);
                //else
                //    oTimeSlot = new DateTime(oCurrentDate.Year, oCurrentDate.Month, oCurrentDate.Day, oCurrentDate.Hour, 0, 0);


                //for (Int32 iCounter = 1; iCounter <= 32; iCounter++)
                //{

                //    Console.WriteLine("Day: " + oTimeSlot.DayOfWeek.ToString() + ", " + oTimeSlot.ToString("m") + " Time: " + oTimeSlot.ToString("t") + " - " + oTimeSlot.AddMinutes(30).ToString("t"));

                //    oTimeSlot = oTimeSlot.AddMinutes(15);
                //    Response.Write("Time: " + oTimeSlot.ToString("t") + " - " + oTimeSlot.AddMinutes(30).ToString("t"));
                //}

                //DateTime startSlot = DateTime.Now.Date.AddHours(8); // Starts at 8:00AM
                //while (startSlot.Hour < 17)
                //{
                //    // Construct time slot class
                //    startSlot = startSlot.AddMinutes(15);
                //}
                //DateTime oCurrentDate1 = new DateTime(2014, 05, 25, 09, 00, 00);
                //DateTime oCurrentDate2 = new DateTime(2014, 05, 25, 05, 00, 00);
                //List<DateTime> list = new List<DateTime>();
                //list.Add(oCurrentDate1);
                //list.Add(oCurrentDate2);


                //appointment.MergeIntoLargerSlots(list, 30);




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }









        //protected void Unnamed1_Click(object sender, EventArgs e)
        //{
        //appointobj.appntId = "APP103";
        //appointobj.dateId = "DAT103";
        //appointobj.doctorId = "DOC103";
        //appointobj.patientId = "PAT103";
        //appointobj.prescriptionId = "PRE103";
        //appointobj.startTime = System.DateTime.Now;
        //appointobj.endTime = System.DateTime.Now;
        //PatientAppointment appoint = new PatientAppointment();
        //appoint.patientappointment();

        //}

        private void getdoctor()
        {
            //DropDownList1.DataTextField = "name";
            //DropDownList1.DataValueField = "doctorId";
            //DropDownList1.DataSource = appointment.SelectAllDoctorData();
            //DropDownList1.DataBind();
        }

        private void GetSpecialist()
        {
            drpSpeciality.DataTextField = "specialize";
            drpSpeciality.DataValueField = "specid";
            drpSpeciality.DataSource = appointment.SelectAllSpecializationData();
            drpSpeciality.DataBind();
        }

        private void GetNationality()
        {
            drpNationality.DataTextField = "Nationality1";
            drpNationality.DataValueField = "Id";
            drpNationality.DataSource = appointment.SelectAllNationalityData();
            drpNationality.DataBind();
        }

        public void GetPrefferedDates()
        {
            drpPreferredDate.DataSource = appointment.returnPreferredDates();
            drpPreferredDate.DataBind();
        }

        public void GetAllDoctor()
        {
            drpDoctor.DataTextField = "name";
            drpDoctor.DataValueField = "doctorId";
            drpDoctor.DataSource = appointment.SelectAllDoctor();
            drpDoctor.DataBind();
        }

        protected void rdbOldReg_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbOldReg.Checked == true)
            {
                rdbNewReg.Checked = false;
                drpDay.Enabled = false;
                drpMonth.Enabled = false;
                drpYear.Enabled = false;
                rdbMale.Enabled = false;
                rdbFemale.Enabled = false;

            }
        }

        protected void rdbNewReg_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNewReg.Checked == true)
            {
                rdbOldReg.Checked = false;
                drpDay.Enabled = true;
                drpMonth.Enabled = true;
                drpYear.Enabled = true;
                rdbMale.Enabled = true;
                rdbFemale.Enabled = true;
            }
        }

        protected void btnAppointment_Click(object sender, EventArgs e)
        {
            string DoctorID = drpDoctor.SelectedValue;
            string name = txtName.Text;
            int phone = Convert.ToInt32(txtContactNo.Text);
            string email = txtEmail.Text;
            string gender="";
            if (rdbMale.Checked == true)
            {
                gender = "M";
            }
            else
            {
                gender = "F";
            }
            string date = drpDay.SelectedItem.ToString() + drpMonth.SelectedItem.ToString()  + drpYear.SelectedItem.ToString();
            DateTime DOB = Convert.ToDateTime(date);            
            string nationality = drpNationality.SelectedItem.ToString();
            string icNum = txtICNo.Text;
            string street = txtStreet.Text;
            string area = txtArea.Text;
            string country = txtCountry.Text;
            int postalCode = Convert.ToInt32(txtPostalCode.Text);
            appointment.CreatePatient(string.Empty, name, phone, email, gender, DOB, nationality, icNum, street, area, country, postalCode);
            appointment.createpatientappointment(string.Empty, String.Empty, "DAT102", DoctorID, DateTime.Now, DateTime.Now, "PRE102");
        }
    }
}
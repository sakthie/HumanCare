using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HumanCare.BLL;
using System.Web.Security;
using System.Globalization;

/**
 * Author - Sakthi.
 * 
 * */

namespace HumareCareWeb
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        PatientAppointment appointment = new PatientAppointment();
        Boolean oldRegTrue = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            //HumareCareWeb.loginBasedonRoles.Utility.ValidateUser(User);


            if (!IsPostBack)
            {
                GetSpecialist();
                GetNationality();
                //GetPrefferedDates();
                GetAllDoctor();
            }
        }

        private void getdoctor()
        {
            //DropDownList1.DataTextField = "name";
            //DropDownList1.DataValueField = "doctorId";
            //DropDownList1.DataSource = appointment.SelectAllDoctorData();
            //DropDownList1.DataBind();
        }

        private void GetSpecialist()
        {
            drpSpeciality.DataTextField = "specialization1";
            drpSpeciality.DataValueField = "id";
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
            drpDoctor.DataValueField = "id";
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
            var patientId = 0;
            //int DoctorID = Convert.ToInt32(drpDoctor.SelectedValue);
            int DoctorID = 1;
            string name = txtName.Text;
            int phone = Convert.ToInt32(txtContactNo.Text);
            string email = txtEmail.Text;
            string gender = "";
            if (rdbMale.Checked == true)
            {
                gender = "M";
            }
            else
            {
                gender = "F";
            }
            string date = drpDay.SelectedItem.ToString() + drpMonth.SelectedItem.ToString() + drpYear.SelectedItem.ToString();
            DateTime DOB = Convert.ToDateTime(date);
            string nationality = drpNationality.SelectedItem.Text;
            string icNum = txtICNo.Text;
            string street = txtStreet.Text;
            string area = txtArea.Text;
            string country = txtCountry.Text;
            string speciality = drpSpeciality.SelectedItem.Text;
            string doctorName = drpDoctor.SelectedItem.Text;
            string appointDate = drpPreferredDate.SelectedItem.Text;
            string format = "MMM d yyyy";

            DateTime appDate = DateTime.ParseExact(appointDate, format, CultureInfo.InvariantCulture);
            string slot = drpTimeSlot.SelectedItem.Text;
            int postalCode = Convert.ToInt32(txtPostalCode.Text);
            if (rdbOldReg.Checked != true && oldRegTrue == false)
            {
                patientId = appointment.CreatePatient(name, phone, email, gender, DOB, nationality, icNum, street, area, country, postalCode);
            }
            appointment.createpatientappointment(patientId, 1, 1, DoctorID, 1, appDate);
            appointment.SendEmailtoPatient(name, icNum, DOB, gender, phone, email, nationality, speciality, doctorName, appointDate, slot);
        }


        protected void rdbMale_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbMale.Checked == true)
            {
                rdbFemale.Checked = false;
            }
        }

        protected void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFemale.Checked == true)
            {
                rdbMale.Checked = false;
            }

        }

        protected void txtICNo_TextChanged(object sender, EventArgs e)
        {
            if (txtICNo.Text != string.Empty)
            {
                var patientlist = appointment.SelectPatientDetails(txtICNo.Text, "", 0);
                if (patientlist != null)
                {
                    if (patientlist.Count > 0)
                    {
                        rdbOldReg.Checked = true;
                        rdbNewReg.Checked = false;
                        txtName.Text = patientlist[0].name.ToString();
                        txtContactNo.Text = patientlist[0].phone.ToString();
                        txtEmail.Text = patientlist[0].email.ToString();
                        if (patientlist[0].gender.ToString() == "M")
                        {
                            rdbMale.Checked = true;
                        }
                        else
                        {
                            rdbFemale.Checked = true;
                        }
                        // drpNationality.SelectedItem.Text = patientlist[0].nationality.ToString();
                        drpNationality.SelectedItem.Text = "India";
                        //drpNationality.SelectedItem.Text = patientlist[0].nationality.ToString();
                        txtStreet.Text = patientlist[0].street;
                        txtArea.Text = patientlist[0].area;
                        txtCountry.Text = patientlist[0].country;
                        txtPostalCode.Text = patientlist[0].postalCode.ToString();
                        oldRegTrue = true;
                        Response.Write(@"<script language='javascript'>alert('Patient already registered with us.please select appointment details');</script>");
                    }
                }

            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Please enter the ICNum to fetch the Details of Patient');</script>");
            }

        }


        protected void drpPreferredDate_SelectedIndexChanged1(object sender, EventArgs e)
        {
            drpTimeSlot.Items.Clear();
            drpTimeSlot.DataTextField = "startTime";
            drpTimeSlot.DataValueField = "slotNo";
            drpTimeSlot.Items.Insert(0, new ListItem("Select", "Select"));
            drpTimeSlot.DataSource = appointment.SelectAppointmentSlot(drpPreferredDate.SelectedItem.ToString());
            drpTimeSlot.DataBind();
            drpTimeSlot.AppendDataBoundItems = true;
            drpTimeSlot.SelectedIndex = 0;
        }


        protected void drpSpeciality_SelectedIndexChanged1(object sender, EventArgs e)
        {
            drpDoctor.Items.Clear();
            drpDoctor.Items.Insert(0, new ListItem("Select", "Select"));
            drpDoctor.DataTextField = "name";
            drpDoctor.DataValueField = "id";
            drpDoctor.DataSource = appointment.SelectDoctorBasedSpec(Convert.ToInt32(drpSpeciality.SelectedValue.ToString()));
            drpDoctor.DataBind();
            drpDoctor.AppendDataBoundItems = true;
            drpDoctor.SelectedIndex = 0;
        }

        protected void drpDoctor_SelectedIndexChanged1(object sender, EventArgs e)
        {
            drpPreferredDate.Items.Clear();
            drpPreferredDate.Items.Insert(0, new ListItem("Select", "Select"));
            drpPreferredDate.DataSource = appointment.returnDatesBasedDoctor(Convert.ToInt32(drpDoctor.SelectedIndex));
            drpPreferredDate.DataBind();
            drpPreferredDate.AppendDataBoundItems = true;
            drpPreferredDate.SelectedIndex = 0;
        }
    }
}
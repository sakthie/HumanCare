using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HumanCare.BLL;
using System.Web.Security;
using System.Globalization;
using System.Transactions;
using HumareCareWeb.loginBasedonRoles;
using HumanCare.BLL.WebFormFacade;

/**
 * Author - Sakthi.
 * 
 * */

namespace HumareCareWeb
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        IPatientRegister appointment = new Facade();
        //PatientAppointment appointment = new PatientAppointment();
        Boolean oldRegTrue = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!User.Identity.IsAuthenticated)
            //    FormsAuthentication.RedirectToLoginPage();
            getDOB();
            if (!IsPostBack)
            {
                PatientRegisterationPanel.Visible = false;
                rdbOldReg.Checked = true;
                rdbNewReg.Checked = false;

                GetSpecialist();
                GetNationality();
                //GetPrefferedDates();
                GetAllDoctor();
                //DOBCalendar.Visible = false;
            }
        }

        protected void rdbOldReg_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbOldReg.Checked == true)
            {
                rdbNewReg.Checked = false;
                PatientRegisterationPanel.Visible = false;
                //rdbMale.Enabled = false;
                //rdbFemale.Enabled = false;

            }
        }

        protected void rdbNewReg_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNewReg.Checked == true)
            {
                rdbOldReg.Checked = false;
                PatientRegisterationPanel.Visible = true;
                //rdbMale.Enabled = true;
                //rdbFemale.Enabled = true;
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
            drpDoctor.DataValueField = "Id";
            drpDoctor.DataSource = appointment.SelectAllDoctor();
            drpDoctor.DataBind();
        }

        public void getDOB()
        {
            List<int> dateValues = new List<int>();
            List<int> monthValues = new List<int>();
            List<int> yearValues = new List<int>();
            for (int i = 1; i <= 31; i++)
            {
                dateValues.Add(i);
                if (i <= 12)
                    monthValues.Add(i);
            }
            for (int i = 1950; i <= DateTime.Now.Year; i++)
                yearValues.Add(i);
            drpDay.DataSource = dateValues;
            drpMonth.DataSource = monthValues;
            drpYear.DataSource = yearValues;
            drpDay.DataBind();
            drpMonth.DataBind();
            drpYear.DataBind();
        }
        protected void btnCheckIc_Click(object sender, EventArgs e)
        {
            string icNum = txtICNo.Text;
            if (icNum != string.Empty)
            {
                var patientlist = appointment.SelectPatientDetails(icNum, "", 0);
                if (rdbNewReg.Checked == true)
                {
                    if (patientlist != null && patientlist.Count > 0)
                    {
                        Response.Write(@"<script language='javascript'>alert('Patient already registered with us.please select appointment details');</script>");
                        rdbOldReg.Checked = true;
                        rdbNewReg.Checked = false;
                        rdbOldReg_CheckedChanged(sender, e);
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Patient Not Registered.Please Enter Patient Details');</script>");
                    }
                }
                else if (rdbOldReg.Checked == true)
                {
                    if (patientlist == null && patientlist.Count == 0)
                    {
                        Response.Write(@"<script language='javascript'>alert('Patient not registered with us.Please Register Patient');</script>");
                        rdbOldReg.Checked = false;
                        rdbNewReg.Checked = true;
                        rdbNewReg_CheckedChanged(sender, e);
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Patient Already Registered.Please Select Appointment Details');</script>");
                    }
                }
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Please enter the ICNum to fetch the Details of Patient');</script>");
            }

        }

        protected void btnAppointment_Click(object sender, EventArgs e)
        {
            int doctorID = Convert.ToInt32(drpDoctor.SelectedValue);
            string appointDate = drpPreferredDate.SelectedItem.Text;
            int patientId = 0;
            int dateId = Convert.ToInt32(drpPreferredDate.SelectedValue.ToString());
            int slotNo = Convert.ToInt32(drpTimeSlot.SelectedValue.ToString());
            string slot = drpTimeSlot.SelectedItem.Text;
            string speciality = drpSpeciality.SelectedItem.Text;
            string doctorName = drpDoctor.SelectedItem.Text;

            string name = null;
            int phone = 0;
            string email = null;
            string gender = "";
            string date = null;
            DateTime DOB = DateTime.Now;
            string nationality = null;
            string street = null;
            string area = null;
            string country = null;

            int postalCode = 0;
            
            if (rdbNewReg.Checked == true)
            {
                name = txtName.Text;
                phone = Convert.ToInt32(txtContactNo.Text);
                email = txtEmail.Text;
                gender = "";
                if (rdbMale.Checked == true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }

                date = drpDay.SelectedItem.ToString() + "/" + drpMonth.SelectedItem.ToString() + "/" + drpYear.SelectedItem.ToString();
                DOB = Convert.ToDateTime(date);
                nationality = drpNationality.SelectedItem.ToString();
                street = txtStreet.Text;
                area = txtArea.Text;
                country = txtCountry.Text;

                postalCode = Convert.ToInt32(txtPostalCode.Text);
            
            }
            string icNum = txtICNo.Text;
            
            
            String formatPatientId = null;
            
            DateTime todayDate = DateTime.Now;
            if (DOB > todayDate && rdbNewReg.Checked==true)
            {
                Response.Write(@"<script language='javascript'>alert('Please Select Valid DOB');</script>");
            }
            else 
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    if (rdbNewReg.Checked == true)
                    {
                        formatPatientId = appointment.CreatePatient(name, phone, email, gender, DOB, nationality, icNum, street, area, country, postalCode);

                    }
                    else if (rdbNewReg.Checked == false)
                    {
                        patientId = appointment.returnPatientfromIC(icNum);
                    }
                    appointment.createpatientappointment(patientId, dateId, doctorID, slotNo);

                    if (rdbNewReg.Checked == true)
                    {
                        appointment.SendEmailtoPatient(name, icNum, DOB, gender, phone, email, nationality, speciality, doctorName, appointDate, slot);
                        Response.Write(@"<script language='javascript'>alert('Patient Registered And Patient ID is " + formatPatientId + " And Appointment Created Successfully');</script>");
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Appointment Created Successfully');</script>");
                    }
                    clearfields();
                }
            }
        }
        protected void rdbMale_CheckedChanged1(object sender, EventArgs e)
        {

            if (rdbMale.Checked == true)
            {
                rdbFemale.Checked = false;
            }
        }

        protected void rdbFemale_CheckedChanged1(object sender, EventArgs e)
        {
            if (rdbFemale.Checked == true)
            {
                rdbMale.Checked = false;
            }
        }

        public void clearfields()
        {
            txtName.Text= string.Empty;
            txtICNo.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtArea.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtStreet.Text = string.Empty;
            drpNationality.SelectedIndex = 0;
            drpTimeSlot.Items.Clear();
            drpTimeSlot.Items.Insert(0, new ListItem("Select", "0"));
            drpTimeSlot.DataBind();
            drpPreferredDate.Items.Clear();
            drpPreferredDate.Items.Insert(0, new ListItem("Select", "0"));
            drpPreferredDate.DataBind();
            drpPreferredDate.SelectedIndex = 0;
            drpSpeciality.SelectedIndex = 0;
            drpTimeSlot.SelectedIndex = 0;
            drpDoctor.Items.Clear();
            GetAllDoctor();
        }
        /*
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

        }*/
        protected void drpPreferredDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpTimeSlot.Items.Clear();
            drpTimeSlot.DataTextField = "startTime";
            drpTimeSlot.DataValueField = "slotNo";
            drpTimeSlot.Items.Insert(0, new ListItem("Select", "0"));
            drpTimeSlot.DataSource = appointment.SelectAppointmentSlot(drpPreferredDate.SelectedItem.ToString());
            drpTimeSlot.DataBind();
            drpTimeSlot.AppendDataBoundItems = true;
            drpTimeSlot.SelectedIndex = 0;
        }

        protected void drpSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpDoctor.Items.Clear();
            drpDoctor.Items.Insert(0, new ListItem("Select", "0"));
            drpDoctor.DataTextField = "name";
            drpDoctor.DataValueField = "Id";
            drpDoctor.DataSource = appointment.SelectDoctorBasedSpec(Convert.ToInt32(drpSpeciality.SelectedValue.ToString()));
            drpDoctor.DataBind();
            drpDoctor.AppendDataBoundItems = true;
            drpDoctor.SelectedIndex = 0;
        }

        protected void drpDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpPreferredDate.Items.Clear();
            drpPreferredDate.Items.Insert(0, new ListItem("Select", "0"));
            drpPreferredDate.DataTextField = "appntDate";
            drpPreferredDate.DataTextFormatString = "{0:dd-MM-yyyy}";
            drpPreferredDate.DataValueField = "dateId";
            drpPreferredDate.DataSource = appointment.returnDatesBasedDoctor(Convert.ToInt32(drpDoctor.SelectedValue.ToString()));
            drpPreferredDate.DataBind();
            drpPreferredDate.AppendDataBoundItems = true;
            drpPreferredDate.SelectedIndex = 0;
        }
    }
}
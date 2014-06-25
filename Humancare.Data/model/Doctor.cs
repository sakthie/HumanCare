using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Humancare.Data
{
    [MetadataType(typeof(DoctorMetaData))]
    public partial class Doctor
    {

        
    }

    public class DoctorMetaData
    {
        [Required(ErrorMessage = "Doctor Name is Required")]
        [DisplayName("Doctor Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dob { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        [DisplayName("Gender")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required")]
        [DisplayName("Mobile")]
        [DataType(DataType.PhoneNumber)]
        public Int32 phone { get; set; }

   

        [Required(ErrorMessage = "Email is Required")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Nationality is Required")]
        [DisplayName("Nationality")]
        [DataType(DataType.Text)]
        public string nationality { get; set; }

        [Required(ErrorMessage = "IC Number is Required")]
        [DisplayName("IC Number")]
        [DataType(DataType.Text)]
        public string icNum { get; set; }

        [Required(ErrorMessage = "Street is Required")]
        [DisplayName("Street")]
        [DataType(DataType.Text)]
        public string street{ get; set; }

        [Required(ErrorMessage = "Area is Required")]
        [DisplayName("Area")]
        [DataType(DataType.Text)]
        public string area { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        [DisplayName("Country")]
        [DataType(DataType.Text)]
        public string country { get; set; }

        [Required(ErrorMessage = "Postal Code is Required")]
        [DisplayName("Postal Code")]
        [DataType(DataType.Text)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Postal Code must be a  number")]
        public int postalCode { get; set; }




    }
}

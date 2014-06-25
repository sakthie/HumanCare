using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Humancare.Data
{
    [MetadataType(typeof(BillMetaData))]
    public partial class Bill
    {
        public Boolean isValid { get; set; }
        public String ErrorMessage{ get; set; }
    }

     public class BillMetaData
     {      
         [Required(ErrorMessage = "Treatment Id is Required")]
         [DisplayName("Treatment Identifier")]
         public int treatmentId { get; set; }

         [Required(ErrorMessage = "Date and time of transaction is required")]
         [DisplayName("Datetime of Tranaction")]
         [DataType(DataType.Date)]
         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
         public DateTime dateOfBill { get; set; }

         [Required(ErrorMessage = "Description for a Bill is Required")]
         [DisplayName("Bill Description")]
         public String description { get; set; }

         [DisplayName("Amount")]
         [Range(1,double.MaxValue,ErrorMessage="Bill amount cannot be less than one Dollar")]
         public decimal amount { get; set; }
     }

   

}

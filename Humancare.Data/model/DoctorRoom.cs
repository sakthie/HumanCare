using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Humancare.Data
{

    

    [MetadataType(typeof(DoctorRoomMetaData))]
    public partial class Doctor_Room
    {
        HealthCareNewEntities entities = new HealthCareNewEntities();
        public bool isValid { get; set; }
        public string errorMessage { get; set; }

        public void Validate()
        {
            isValid = true;
            errorMessage = string.Empty;

            //1. Past Date
            if (this.startDateTime < DateTime.Now.Date || this.endDateTime < DateTime.Now.Date)
            {
                isValid = false;
                errorMessage = "Past date is not allowed";
                return;
            }

            //2. Start date cannot be after End date
            if (this.startDateTime > this.endDateTime)
            {
                 isValid = false;
                errorMessage = "Start date cannot be after End date";
                return;
            }

            //3. Is Room alread assigned to Some any doctor?
            var doctor_room = (from dr in entities.Doctor_Room where dr.roomId == this.roomId && ((dr.startDateTime >= this.startDateTime && dr.endDateTime <= this.startDateTime) || (dr.startDateTime >= this.endDateTime && dr.endDateTime <= this.endDateTime ))select dr).FirstOrDefault();
           // Doctor_Room doctor_room = entities.Doctor_Room.Single(d => (d.roomId == this.roomId && ((d.startDateTime >= this.startDateTime && d.endDateTime <= this.startDateTime) || (d.startDateTime >= this.endDateTime && d.endDateTime <= this.endDateTime))));
            if (doctor_room != null)
            {
                isValid = false;
                errorMessage = "Room is alread assigned to Some other doctor";
            }
            else
            {
                isValid = true;
                errorMessage = string.Empty;
            }



        }

        

    }

    public class DoctorRoomMetaData
    {
        [Required(ErrorMessage = "Start Date is Required")]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime startDateTime { get; set; }

        [Required(ErrorMessage = "End Date is Required")]
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime endDateTime { get; set; }
    }



}

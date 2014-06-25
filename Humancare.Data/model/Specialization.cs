using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Humancare.Data
{
    [MetadataType(typeof(SpecializationMetadata))]
    public partial  class Specialization
    {
   
    }

    public class SpecializationMetadata
    {
        [Required(ErrorMessage = "Specializtion Name is Required")]
        [DisplayName("Specialization Name")]
        public string specialization { get; set; }


    }
}

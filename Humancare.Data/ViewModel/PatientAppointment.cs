using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Humancare.Data.ViewModel
{
    public class PatientAppointment
    {
        public class patientapp
        {
            public string name { get; set; }
            public string gender { get; set; }
            public int appntId { get; set; }
            public DateTime appntDate { get; set; }
            public string startTime { get; set; }
            public string endTime { get; set; }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonResources.Models
{
    public class PatientAssignment
    {

        public Guid DoctorId { get; set; }
        public List<Guid> Patientid { get; set; }
    }
}

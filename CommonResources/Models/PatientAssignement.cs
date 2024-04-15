using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonResources.Models
{
    public class PatientAssignement
    {
        public Guid Id { get; set; }    
        public Guid DoctorId { get; set; }
        public List<Guid> PatientId { get; set; }
    }
}

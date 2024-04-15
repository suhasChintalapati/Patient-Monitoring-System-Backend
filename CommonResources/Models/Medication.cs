using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonResources.Models
{
    public class Medication
    {
        public Guid DoctorId {  get; set; }
        public Guid PatientId { get; set; }
        public DateTime date {  get; set; }
        public List<Medicines>Medicines { get; set; }
    }
}

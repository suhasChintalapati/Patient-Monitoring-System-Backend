using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonResources.Models
{
    public class DoctorsInfo
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Email {  get; set; }
        public Guid DoctorId { get; set; }
        public string Password { get; set; }    
        public string Speciality {  get; set; }
        //public List<Guid> PatientIds { get; set; }
        public string Address {  get; set; }
        public string Type { get; set; }
        

    }
}

using CommonResources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorServices
{
    public interface IDoctorService
    {
        Task CreateDoctor(DoctorsInfo doctorsInfo);
        Task Deletedoctor(Guid doctorId);
        Task PatientAssinging(Guid DoctorId, Guid PatientId);
        Task<Guid> DoctorLogin(String Email, string Password);
    }


}

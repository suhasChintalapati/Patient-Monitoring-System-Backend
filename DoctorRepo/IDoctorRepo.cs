using CommonResources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Text;
using System.Threading.Tasks;

namespace DoctorRepo
{
    public interface IDoctorRepo
    {
       
        Task AddMedication(Guid PatientId,Guid DoctorId);
        Task RemoveMedication(Guid PatientId,Guid DoctorId);
        Task<List<PatientInfo>> GetAllAssignedPatients(Guid DoctorId);
        Task CreateDoctor(DoctorsInfo doctorInfo);



    }
}

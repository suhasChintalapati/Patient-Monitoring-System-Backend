using CommonResources.Models;
using DoctorRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepo;
        public DoctorService(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }
        public async Task CreateDoctor(DoctorsInfo doctorsInfo)
        {
             await _doctorRepo.CreateDoctor(doctorsInfo);
        }

        public async  Task Deletedoctor(Guid doctorId)
        {
            await _doctorRepo.DeleteDoctor(doctorId);
        }

        public async Task<Guid> DoctorLogin(string Email, string Password)
        {
            return await _doctorRepo.LoginDoctor(Email, Password);
        }

        public async Task PatientAssinging(Guid DoctorId, Guid PatientId)
        {
           await _doctorRepo.AssigningPatients(DoctorId, PatientId);
        }
    }
}

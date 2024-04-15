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
        private readonly IDoctorRepo _repo;
        public DoctorService(IDoctorRepo doctorRepo) {
        _repo = doctorRepo;
        
        }  
        public Task CreateDoctor(DoctorsInfo doctorsInfo)
        {
            return 
        }
    }
}

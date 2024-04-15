using CommonResources.Models;
using DoctorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientMonitoringSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpPost]
        public async Task CreateDoctor(DoctorsInfo doctorsInfo)
        {
            await _doctorService.CreateDoctor(doctorsInfo);
        }
        [HttpDelete]
        public async Task DeleteDoctor(Guid id)
        {
            await _doctorService.Deletedoctor(id);
        }
        [HttpPut]
        public async Task PatientAssignment(Guid DoctorId,Guid PatientId)
        {
            await _doctorService.PatientAssinging(DoctorId, PatientId);
        }
    }
}

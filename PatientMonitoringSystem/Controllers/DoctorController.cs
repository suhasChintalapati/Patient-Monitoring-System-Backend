using CommonResources.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientMonitoringSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        [HttpPost]
        public Task CreatePatient(DoctorsInfo doctorsInfo)
        {
            
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientVitalsServices;
using CommonResources.Models;
using System.ComponentModel;
using System.Collections.Specialized;


namespace PatientMonitoringSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientVitalsController : ControllerBase
    {

        private readonly IPatientVitalsService _patientService;
        public PatientVitalsController(IPatientVitalsService patientService)
        {
            _patientService = patientService;


        }
        [HttpGet]
        public async Task<List<PatientInfo>> GetAllPatients()
        {
            return await _patientService.GetAllPatients();
        }
        [HttpGet("{id}")]
        public async Task<List<PatientVitalsInfo>> GetPatientVitals(Guid id)
        {
            
               return await _patientService.GetAllVitals(id);
        }

        [HttpGet("{id}")]
        public async Task<PatientVitalsInfo> GetLatestPatientVitalInfo(Guid id)
        {
            return await _patientService.GetLatestVital(id);
        }
       
        [HttpPost]
        public async Task CreatePatient(PatientInfo patient)
        {
            await _patientService.CreatePatient(patient);
        }
        [HttpPost]
        public async Task CreatePatientVitals(PatientVitalsInfo patientVitalsInfo)
        {
            await _patientService.CreateVitals(patientVitalsInfo);
        }
        [HttpGet]
        public async Task<PatientVitalsInfo> GetMeanOfPatientVitals(Guid id)
        {
            return await _patientService.GetMeanPatientVital(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonResources.Models;

namespace PatientVitalsServices
{
    public interface IPatientVitalsService
    {

        Task<List<PatientVitalsInfo>> GetAllVitals(Guid id);
        Task CreatePatient(PatientInfo patientInfo);
        Task<PatientVitalsInfo> GetLatestVital(Guid id);
        Task<List<PatientInfo>> GetAllPatients();
        Task CreateVitals(PatientVitalsInfo student);
        Task<PatientVitalsInfo>GetMeanPatientVital(Guid id);
    }
}

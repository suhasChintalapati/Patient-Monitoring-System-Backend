using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonResources.Models;

namespace PatientVitalsRepo
{
    public interface IPatientVitalsRepo
    {
        Task<List<PatientVitalsInfo>> GetAllPatientVitalsData(Guid id);
        Task CreatePatient(PatientInfo Info);
        Task CreatePatientVital(PatientVitalsInfo vitals);
        Task<PatientVitalsInfo> GetLatestData(Guid id);
        Task<List<PatientInfo>> GetAllPatients();
        Task DeleteOutDatedVitals(Guid id);
    }
}

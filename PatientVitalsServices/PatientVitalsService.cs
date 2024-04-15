using CommonResources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientVitalsRepo;
namespace PatientVitalsServices
{
    public class PatientVitalsService : IPatientVitalsService
    {
        private readonly IPatientVitalsRepo _patientVitalRepo;

        public PatientVitalsService(IPatientVitalsRepo patientVitalsRepo)
        {
            _patientVitalRepo = patientVitalsRepo;
        }
        public async Task CreatePatient(PatientInfo patientInfo)
        {
            await _patientVitalRepo.CreatePatient(patientInfo);
        }

        public async Task CreateVitals(PatientVitalsInfo vitalsInfo)
        {
            await _patientVitalRepo.CreatePatientVital(vitalsInfo);
        }

        public async Task<List<PatientInfo>> GetAllPatients()
        {
           return await _patientVitalRepo.GetAllPatients();
        }

        public async Task<List<PatientVitalsInfo>> GetAllVitals(Guid id)
        {
            return await _patientVitalRepo.GetAllPatientVitalsData(id);
        }

        public async Task<PatientVitalsInfo> GetLatestVital(Guid id)
        {
            return await _patientVitalRepo.GetLatestData(id);
        }

        public async  Task<PatientVitalsInfo> GetMeanPatientVital(Guid id)
        {
            List<PatientVitalsInfo> Patients = await _patientVitalRepo.GetAllPatientVitalsData(id);
            PatientVitalsInfo PatientMean = new PatientVitalsInfo();
            List<double> Bp= new List<double>();
            List<double> ECG= new List<double>();
            List<double> Temp= new List<double>();
            foreach (var Patient in Patients)
            {
                Bp.Add(double.Parse(Patient.bp));
                ECG.Add(double.Parse(Patient.ecg));
                Temp.Add(double.Parse(Patient.temp));
            }
            PatientMean.patientId = id;
            PatientMean.type = "Vitals";
            PatientMean.bp=Bp.Average().ToString();
            PatientMean.ecg=ECG.Average().ToString();
            PatientMean.temp=Temp.Average().ToString();
            PatientMean.CreatedTime = DateTime.UtcNow;
            return PatientMean;
        }

        public Task<Guid> PatientLogin(string userName, string password)
        {
            return _patientVitalRepo.PatientLogin(userName, password);
        }
    }
}

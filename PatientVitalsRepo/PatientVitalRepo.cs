using CommonResources.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace PatientVitalsRepo
{
    public class PatientVitalRepo : IPatientVitalsRepo
    {
        private readonly CosmosClient _client;  
        private readonly Database _database;
        private readonly Container _container;
        private readonly string _databaseId;
        public PatientVitalRepo(CosmosClient client,string DatabaseId)
        {
            _client = client;  
            _databaseId = DatabaseId;
            _database = _client.GetDatabase(_databaseId);
            _container=_database.GetContainer("Patients");

        }
        public async Task CreatePatient(PatientInfo Info)
        {
            Info.id = Guid.NewGuid();
            Info.PatientId = Info.id;
            await _container.CreateItemAsync<PatientInfo>(Info,new PartitionKey(Info.PatientId.ToString()));
        }

        public async Task CreatePatientVital(PatientVitalsInfo vitals)
        {
          vitals.id= Guid.NewGuid();
            await _container.CreateItemAsync<PatientVitalsInfo>(vitals,new PartitionKey(vitals.patientId.ToString()));
        }

        public async Task DeleteOutDatedVitals(Guid id)
        {
            DateTime time = DateTime.UtcNow;
            QueryDefinition query = new  QueryDefinition($"select * from Patients where and Patients.id='{id}' Patients.type='Vitals' and Patients.CreatedTime<'{time}'");

        }

        public async Task<List<PatientInfo>> GetAllPatients()
        {
            QueryDefinition query=new QueryDefinition($"Select * from Patients where Patients.type='Patient'");
            var iterator=_container.GetItemQueryIterator<PatientInfo>(query);
            while (iterator.HasMoreResults)
            {
               var result=await iterator.ReadNextAsync();
                return result.ToList();
                
            }
            return null;
        }

        public async Task<List<PatientVitalsInfo>> GetAllPatientVitalsData(Guid id)
        {
            
            QueryDefinition query = new QueryDefinition($"Select * from Patients where Patients.patientId='{id}' and Patients.type='Vitals'");
            var iterator=_container.GetItemQueryIterator<PatientVitalsInfo>(query);
           while(iterator.HasMoreResults)
            {
                var result=  await iterator.ReadNextAsync();
                return result.ToList();
            }

            return null;
        }

        public async Task<PatientVitalsInfo> GetLatestData(Guid id)
        {
            int limit = 1;
            QueryDefinition query = new QueryDefinition($"Select TOP {limit} *  from Patients where Patients.patientId='{id}' and Patients.type='Vitals' order by Patients.CreatedTime DESC ");
            var iterator = _container.GetItemQueryIterator<PatientVitalsInfo>(query);
            while (iterator.HasMoreResults)
            {
                var result = await iterator.ReadNextAsync();
                return result.FirstOrDefault();
            }
            return null;
        }

        public async Task<Guid> PatientLogin(string email, string password)
        {
            try
            {
                QueryDefinition query = new QueryDefinition($"Select * from Patients where  Patients.type='Patient' and Patients.email='{email}' and Patients.password='{password}' ");
                var iterator = _container.GetItemQueryIterator<PatientInfo>(query);
                while (iterator.HasMoreResults)
                {
                    var result = await iterator.ReadNextAsync();

                    return result.FirstOrDefault().PatientId;
                }
                return Guid.Empty;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Guid.Empty;
            }
        }
    }
}

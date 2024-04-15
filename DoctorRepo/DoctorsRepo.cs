using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CommonResources.Models;
using Microsoft.Azure.Cosmos;

namespace DoctorRepo
{
    public class DoctorsRepo:IDoctorRepo
    {
        private readonly CosmosClient _client;
        private readonly Database _database;
        private readonly Container _container;
        private readonly string _databaseId;
       public DoctorsRepo(CosmosClient cosmosClient,string databaseId)
        {
            _client = cosmosClient;
            _database=_client.GetDatabase(databaseId);
            _container=_database.GetContainer("Doctors");
        }

        public async Task AssigningPatients(Guid doctorId, Guid patientId)
        {
            try
            {
                
                var response = await _container.ReadItemAsync<PatientAssignement>(doctorId.ToString(), new PartitionKey($"{doctorId.ToString()}"));
                dynamic result = response.Resource;
                List<Guid> patientIds = new List<Guid>();
                foreach (var item in result.patientId)
                {
                    patientIds.Add(item.PatientId);
                }
                patientIds.Add(patientId);
                PatientAssignement patientAssignement = new PatientAssignement()
                {
                    DoctorId = result.Id,
                    PatientId = patientIds
                };
                await _container.ReplaceItemAsync<dynamic>(patientAssignement, patientAssignement.DoctorId.ToString(), new PartitionKey(patientAssignement.DoctorId.ToString()));

            }




            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                List<Guid> patId = new List<Guid>();
                patId.Add(patientId);

                PatientAssignement patientAssignement = new PatientAssignement()
                {
                    DoctorId = doctorId,
                    PatientId = patId

                };
                await _container.CreateItemAsync<dynamic>(patientAssignement);
            }
               
           

        }


        public async Task CreateDoctor(DoctorsInfo doctorInfo)
        {
            doctorInfo.Id=Guid.NewGuid();
            doctorInfo.DoctorId=doctorInfo.Id;
            await _container.CreateItemAsync(doctorInfo);
        }

        public async Task DeleteDoctor(Guid DoctorId)
        {
            await _container.DeleteItemAsync<dynamic>(DoctorId.ToString(), new PartitionKey($"{DoctorId.ToString()}"));
            
        }

        public Task<List<PatientInfo>> GetAllAssignedPatients(Guid DoctorId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatingMedication()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<List<PatientInfo>> GetAllAssignedPatients(Guid DoctorId)
        {
            throw new NotImplementedException();
        }

        public Task AddMedication(Guid PatientId, Guid DoctorId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMedication(Guid PatientId, Guid DoctorId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateDoctor(DoctorsInfo doctorInfo)
        {
            doctorInfo.Id = Guid.NewGuid();
            await _container.CreateItemAsync(doctorInfo);

        }
    }
}

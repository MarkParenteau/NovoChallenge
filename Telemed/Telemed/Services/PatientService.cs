using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Database;
using Utils.Models;

namespace TelemedApi.Services
{
    public class PatientService
    {
        private readonly IMongoCollection<Patient> patientsCollection;

        public PatientService(DatabaseSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            patientsCollection = database.GetCollection<Patient>(dbSettings.PatientsCollectionName);
        }

        public List<Patient> GetAllPatients()
        {
            return patientsCollection.Find(patient => true).ToList();
        }

        public Patient GetPatient(string id)
        {
            return patientsCollection.Find<Patient>(patient => patient.Id == id).FirstOrDefault();
        }

        public Patient CreatePatient(Patient patient)
        {
            patientsCollection.InsertOne(patient);
            return patient;
        }

        public void UpdatePatient(string id, Patient patient)
        {
            patientsCollection.ReplaceOne(p => p.Id == id, patient);
        }

        public void RemovePatient(string id)
        {
            patientsCollection.DeleteOne(patient => patient.Id == id);
        }
    }
}

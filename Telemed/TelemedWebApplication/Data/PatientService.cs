using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Utils.Models;

namespace TelemedWebApplication.Data
{
    public class PatientService
    {
        public Task<List<Patient>> GetPatients()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:44347/api/patient").Result;
            string callResult = "";
            List<Patient> patients = new List<Patient>();
            if (response.IsSuccessStatusCode)
            {
                callResult = response.Content.ReadAsStringAsync().Result;
                patients = JsonConvert.DeserializeObject<List<Patient>>(callResult);
            }

            return Task.FromResult(patients);
        }

        public Task<Patient> GetPatient(string id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44347/api/patient/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            string callResult = "";
            Patient patient = null;
            if (response.IsSuccessStatusCode)
            {
                callResult = response.Content.ReadAsStringAsync().Result;
                patient = JsonConvert.DeserializeObject<Patient>(callResult);
            }

            return Task.FromResult(patient);
        }

        public Task<Patient> CreatePatient(Patient patient)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44347/api/patient/" + patient.Id;

            HttpResponseMessage response = client.PostAsJsonAsync(url, patient).Result;
            string callResult = "";
            if (response.IsSuccessStatusCode)
            {
                callResult = response.Content.ReadAsStringAsync().Result;
                patient = JsonConvert.DeserializeObject<Patient>(callResult);
            }

            return Task.FromResult(patient);
        }

        public Task<Patient> UpdatePatient(Patient patient)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44347/api/patient/" + patient.Id;

            HttpResponseMessage response = client.PutAsJsonAsync(url, patient).Result;
            string callResult = "";
            if (response.IsSuccessStatusCode)
            {
                callResult = response.Content.ReadAsStringAsync().Result;
                patient = JsonConvert.DeserializeObject<Patient>(callResult);
            }

            return Task.FromResult(patient);
        }

        public Task<string> DeletePatient(string patientId)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44347/api/patient/" + patientId;

            HttpResponseMessage response = client.DeleteAsync(url).Result;
            string callResult = "";
            if (response.IsSuccessStatusCode)
            {
                callResult = response.Content.ReadAsStringAsync().Result;
            }

            return Task.FromResult(callResult);
        }

        /// <summary>
        /// This method is used to simulate a vital sign reading
        /// It generates a new random vital sign and adds it to it's patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public Task<Patient> TakeNewVitalSignReading(Patient patient)
        {
            VitalSign vitalSign = new VitalSign();
            var random = new Random();
            vitalSign.CardiacFrequency = random.Next(0, 100);
            vitalSign.Temperature = random.Next(10, 35);
            vitalSign.SpO2 = random.Next(80, 100);
            vitalSign.CreationTime = DateTime.Now;
            patient.VitalSigns.Add(vitalSign);


            //In theory, we might consider only updating the patient every few reads to not put as much pressure on the API servers,
            // but since this is more of a demo  than anything, I'll let it update every time
            return UpdatePatient(patient);
        }
    }
}

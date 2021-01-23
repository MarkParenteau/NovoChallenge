using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Utils.Models;

namespace TelemedWebApp.Data
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

        public Task<Patient> GetService(string id)
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
    }
}

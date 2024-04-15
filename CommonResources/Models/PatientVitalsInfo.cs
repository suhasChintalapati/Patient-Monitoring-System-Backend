using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonResources.Models
{
    public class PatientVitalsInfo
    {
        
        [JsonRequired]
        public Guid id { get; set; }
        [JsonRequired]
        public Guid patientId {  get; set; }
        [JsonRequired]
        public string type {  get; set; }
        [JsonRequired]
        public string ecg { get; set; }
        [JsonRequired]
        public string bp {  get; set; }
        [JsonRequired]
        public string temp {  get; set; }

        [JsonRequired]
        public DateTime CreatedTime { get; set; }

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonResources.Models
{
    public class PatientInfo
    {
        [JsonRequired]
       
        public Guid id { get; set; }
        [JsonRequired]
        public string name { get; set; }
        [JsonRequired]
        public string email { get; set; }
        [JsonRequired]
        public string number { get; set; }
        [JsonRequired]
        public string password {  get; set; }
        [JsonRequired]
        public Guid PatientId {  get; set; }
        [JsonRequired]
        public string Address {  get; set; }
        [JsonRequired]
        public string type { get; set; }

    }
}

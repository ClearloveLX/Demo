using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapTableDemo.Models
{
    public class EmployeeList
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Gender")]
        public int Gender { get; set; }
        [JsonProperty("Department")]
        public int Department { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("DepartmentsName")]
        public string DepartmentsName { get; set; }
    }
}

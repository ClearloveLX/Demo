using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapTableDemo.Models
{
    public class InfoDepartment
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }

        public virtual ICollection<InfoEmployee> Employees { get; set; }
    }
}

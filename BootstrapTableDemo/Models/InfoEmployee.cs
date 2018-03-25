using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapTableDemo.Models
{
    public class InfoEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public int Department { get; set; }

        public virtual InfoDepartment Departments { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Serialization.Model
{
    [Serializable]
    public class Department
    {
        public string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}

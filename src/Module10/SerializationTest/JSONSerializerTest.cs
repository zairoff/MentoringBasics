using Serialization;
using Serialization.Model;
using System.Collections.Generic;
using Xunit;

namespace SerializationTest
{
    public class JSONSerializerTest
    {
        [Fact]
        public void Serialize_Deserialize_AsJson()
        {
            var departmnent = new Department
            {
                DepartmentName = "IT",
                Employees = new List<Employee>
                {
                    new Employee { EmployeeName = "Maruf" },
                    new Employee { EmployeeName = "Zair" }
                }
            };

            var jsonSerializer = new JSONSerializer(new FileSystem());

            jsonSerializer.Serialize(departmnent, "json.json");

            var result = jsonSerializer.Desirialize<Department>("json.json");

            Assert.Equal(departmnent.DepartmentName, result.DepartmentName);
        }
    }
}

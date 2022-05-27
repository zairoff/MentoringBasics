using Serialization;
using Serialization.Model;
using System.Collections.Generic;
using Xunit;

namespace SerializationTest
{
    public class BinarySerializationTests
    {
        [Fact]
        public void Serialize_And_Deserialize_Should_Serialize_Object_AsBinary_And_Deserialize()
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

            var binarySerializer = new BinarySerializer(new FileSystem());
            
            binarySerializer.Serialize(departmnent, "binary.txt");

            var result = binarySerializer.Desirialize<Department>("binary.txt");

            Assert.Equal(departmnent.DepartmentName, result.DepartmentName);
        }
    }
}

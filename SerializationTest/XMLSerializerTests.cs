using Serialization;
using Serialization.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SerializationTest
{
    public class XMLSerializerTests
    {
        [Fact]
        public void Serialize_And_Deserialize_Should_Serialize_Object_AsXml_And_Deserialize()
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

            var xmlSerializer = new XMLSerializer(new FileSystem());

            xmlSerializer.Serialize(departmnent, "xml.xml");

            var result = xmlSerializer.Desirialize<Department>("xml.xml");

            Assert.Equal(departmnent.DepartmentName, result.DepartmentName);
        }
    }
}

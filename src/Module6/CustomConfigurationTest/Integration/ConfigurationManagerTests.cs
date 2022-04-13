using CustomConfiguration;
using CustomConfigurationTest.Modules;
using Xunit;

namespace CustomConfigurationTest.Integration
{
    public class ConfigurationManagerTests
    {
        [Fact]
        public void LoadConfiguration()
        {
            var expectedName = "Mz";
            var expectedValue = "21";

            var configurationManager = new ConfigurationManager();
            var result = configurationManager.LoadConfiguration<TestConfiguration>();

            Assert.Equal(expectedName, result.Name);
            Assert.Equal(expectedValue, result.Value);
        }
    }
}
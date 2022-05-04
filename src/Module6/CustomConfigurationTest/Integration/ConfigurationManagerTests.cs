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

        [Fact]
        public void SaveConfiguration()
        {
            var configuration = new TestConfiguration
            {
                Name = "Quality",
                Value = "17"
            };

            var configurationManager = new ConfigurationManager();
            configurationManager.SaveConfiguration(configuration);
            var result = configurationManager.LoadConfiguration<TestConfiguration>();


            Assert.Equal(configuration.Name, result.Name);
            Assert.Equal(configuration.Value, result.Value);
        }
    }
}
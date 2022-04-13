using CustomConfiguration;
using CustomConfigurationTest.Modules;
using Xunit;

namespace CustomConfigurationTest
{
    public class ConfigurationManagerTests
    {
        [Fact]
        public void LoadConfiguration()
        {
            var configurationManager = new ConfigurationManager();
            configurationManager.LoadConfiguration<TestConfiguration>();
        }
    }
}
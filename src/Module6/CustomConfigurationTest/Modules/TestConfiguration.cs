using CustomConfiguration;
using CustomConfiguration.Attributes;
using CustomConfiguration.Enum;

namespace CustomConfigurationTest.Modules
{
    [Configuration(@"C:\Projects\SMT\src\SMT.Api\appsettings.json", "Test", ProviderType.Json)]
    internal class TestConfiguration : BaseConfiguration
    {
        [ConfigurationProperty("Name")]
        public string? Name { get; set; }

        [ConfigurationProperty("Value")]
        public string? Value { get; set; }
    }
}

using CustomConfiguration;
using CustomConfiguration.Attributes;
using CustomConfiguration.Enum;

namespace CustomConfigurationTest.Modules
{
    [Configuration("fakePath", ProviderType.Xml)]
    internal class TestConfiguration : BaseConfiguration
    {
        [ConfigurationProperty("name")]
        public string? Name { get; set; }

        [ConfigurationProperty("integer")]
        public int Integer { get; set; }
    }
}

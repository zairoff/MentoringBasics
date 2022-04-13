using CustomConfiguration.ConfigurationProviders;
using CustomConfiguration.Enum;

namespace CustomConfiguration.Factory
{
    public class ConfigurationProviderFactory
    {
        public static IConfigurationProvider GetConfigurationProvider(ProviderType provider, string path, string section)
        {
            IConfigurationProvider configurationProvider;
            switch (provider)
            {
                case ProviderType.Xml: configurationProvider = new XmlConfigurationProvider(path); break;
                case ProviderType.Json: configurationProvider = new JsonConfigurationProvider(path, section); break;
                default: configurationProvider = new XmlConfigurationProvider(path); break;
            }

            return configurationProvider;
        }
    }
}

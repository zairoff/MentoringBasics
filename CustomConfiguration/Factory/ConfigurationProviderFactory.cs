using CustomConfiguration.ConfigurationProviders;
using CustomConfiguration.Enum;

namespace CustomConfiguration.Factory
{
    public class ConfigurationProviderFactory
    {
        public static IConfigurationProvider GetConfigurationProvider(ProviderType provider, string path)
        {
            IConfigurationProvider configurationProvider;
            switch (provider)
            {
                case ProviderType.Xml: configurationProvider = new XmlConfigurationProvider(path); break;
                default: configurationProvider = new XmlConfigurationProvider(path); break;
            }

            return configurationProvider;
        }
    }
}

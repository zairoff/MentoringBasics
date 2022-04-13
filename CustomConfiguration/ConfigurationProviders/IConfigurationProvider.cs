using System.Collections.Generic;

namespace CustomConfiguration.ConfigurationProviders
{
    public interface IConfigurationProvider
    {
        void SaveConfiguration(Dictionary<string, string> configuration);
        Dictionary<string, string> LoadConfiguration();
    }
}

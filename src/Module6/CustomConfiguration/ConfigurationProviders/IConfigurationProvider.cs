using System.Collections.Generic;

namespace CustomConfiguration.ConfigurationProviders
{
    public interface IConfigurationProvider
    {
        void SaveConfiguration(Dictionary<string, object> configuration);
        Dictionary<string, object> LoadConfiguration();
    }
}

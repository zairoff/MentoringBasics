using CustomConfiguration.Factory;
using System;

namespace CustomConfiguration
{
    public class ConfigurationManager
    {
        private ConfigurationProviderFactory _providerFactory;

        public T LoadConfiguration<T>()
        {
            throw new NotImplementedException();
        }

        public void SaveConfiguration<T>(T configuration)
        {
            throw new NotSupportedException();
        }
    }
}

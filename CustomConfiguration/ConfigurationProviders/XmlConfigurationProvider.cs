using System;
using System.Collections.Generic;
using System.Text;

namespace CustomConfiguration.ConfigurationProviders
{
    public class XmlConfigurationProvider : IConfigurationProvider
    {
        private readonly string _path;

        public XmlConfigurationProvider(string path)
        {
            _path = path;
        }

        public Dictionary<string, string> LoadConfiguration()
        {
            return new Dictionary<string, string> { { "integer", "1" } };
        }

        public void SaveConfiguration(Dictionary<string, string> configuration)
        {
            throw new NotImplementedException();
        }
    }
}

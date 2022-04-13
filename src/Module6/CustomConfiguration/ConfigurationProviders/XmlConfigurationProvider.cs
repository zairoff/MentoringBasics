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

        public Dictionary<string, object> LoadConfiguration()
        {
            return new Dictionary<string, object> { { "integer", "1" }, { "name", "Cookie" } };
        }

        public void SaveConfiguration(Dictionary<string, object> configuration)
        {
            throw new NotImplementedException();
        }
    }
}

using CustomConfiguration.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomConfiguration.ConfigurationProviders
{
    public class JsonConfigurationProvider : IConfigurationProvider
    {
        private readonly IConfiguration _configuration;
        private readonly string _section;

        public JsonConfigurationProvider(string path, string section)
        {
            _section = section;
           _configuration = new ConfigurationBuilder()
                            .AddJsonFile(path, optional: true, reloadOnChange: true)
                            .Build();

        }

        public Dictionary<string, object> LoadConfiguration()
        {
            var section = _configuration.GetSection(_section);

            var items = section.GetChildren();

            var result = new Dictionary<string, object>();
            foreach (var item in items)
            {
                result.Add(item.Key, item.Value);
            }

            return result;
        }

        public void SaveConfiguration(Dictionary<string, object> keyValuePairs)
        {
            var section = _configuration.GetSection(_section);

            var isSectionExists = section.Exists();

            if (!isSectionExists)
                throw new SectionNotFoundException($"Section {_section} not found");

            var items = section.GetChildren();

            foreach (var item in items)
            {
                if(keyValuePairs.TryGetValue(item.Key, out object value))
                {
                    _configuration[item.Key] = value.ToString();
                }
            }
        }
    }
}

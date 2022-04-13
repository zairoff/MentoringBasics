using CustomConfiguration.Attributes;
using CustomConfiguration.Factory;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CustomConfiguration
{
    public class ConfigurationManager
    {
        private Dictionary<string, string> _configuration;
        public T LoadConfiguration<T>()  where T : BaseConfiguration, new()
        {
            var result = new T();
            var configurationAttribute = typeof(T).GetCustomAttributes(typeof(ConfigurationAttribute), true)
                .FirstOrDefault() as ConfigurationAttribute;

            if (configurationAttribute == null)
                throw new InvalidOperationException("Custom attribute not found");

            var configurationProvider = ConfigurationProviderFactory.GetConfigurationProvider(configurationAttribute.ProviderType, configurationAttribute.Path);

            _configuration = configurationProvider.LoadConfiguration();

            var propertyAttributes = typeof(T).GetCustomAttributes(typeof(ConfigurationPropertyAttribute), true)
                .Select(p => p as ConfigurationPropertyAttribute);

            foreach (var property in typeof(T).GetProperties())
            {
                var propertyAttribute = typeof(T).GetCustomAttributes(typeof(ConfigurationPropertyAttribute), true)
                    .FirstOrDefault() as ConfigurationPropertyAttribute;

                if (propertyAttribute == null)
                    continue;

                if(_configuration.TryGetValue(propertyAttribute.Key, out var value))
                {
                    property.SetValue(result, value);
                }
            }

            return result;
        }

        public void SaveConfiguration<T>(T configuration)
        {
            throw new NotSupportedException();
        }
    }
}

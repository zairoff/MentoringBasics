using CustomConfiguration.Attributes;
using CustomConfiguration.Factory;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;

namespace CustomConfiguration
{
    public class ConfigurationManager
    {
        private Dictionary<string, object> _configuration;
        public T LoadConfiguration<T>()  where T : BaseConfiguration, new()
        {
            var result = new T();
            var configurationAttribute = GetConfigurationAttribute<T>();

            if (configurationAttribute == null)
                throw new InvalidOperationException("Custom attribute not found");

            var configurationProvider = ConfigurationProviderFactory
                .GetConfigurationProvider(configurationAttribute.ProviderType,
                                            configurationAttribute.Path,
                                            configurationAttribute.Section);

            _configuration = configurationProvider.LoadConfiguration();

            foreach (var property in typeof(T).GetProperties())
            {
                var propertyAttribute = GetConfigurationPropertyAttribute(property);

                if (propertyAttribute == null)
                    continue;

                if(_configuration.TryGetValue(propertyAttribute.Key, out var value))
                {
                    property.SetValue(result, (value));
                }
            }

            return result;
        }

        public void SaveConfiguration<T>(T configuration)
        {
            var configurationAttribute = GetConfigurationAttribute<T>();

            if (configurationAttribute == null)
                throw new InvalidOperationException("Custom attribute not found");

            var configurationProvider = ConfigurationProviderFactory
                .GetConfigurationProvider(configurationAttribute.ProviderType,
                                            configurationAttribute.Path,
                                            configurationAttribute.Section);

            var result = new Dictionary<string, object>();

            foreach (var property in typeof(T).GetProperties())
            {
                var propertyAttribute = GetConfigurationPropertyAttribute(property);

                if (propertyAttribute == null)
                    continue;

                result.Add(propertyAttribute.Key, property.GetValue(configuration));
            }

            configurationProvider.SaveConfiguration(result);
        }

        private ConfigurationAttribute GetConfigurationAttribute<T>()
        {
            return typeof(T).GetCustomAttributes(typeof(ConfigurationAttribute), true)
                .FirstOrDefault() as ConfigurationAttribute;
        }

        private ConfigurationPropertyAttribute GetConfigurationPropertyAttribute(PropertyInfo property)
        {
            return property.GetCustomAttributes(typeof(ConfigurationPropertyAttribute), true)
                    .FirstOrDefault() as ConfigurationPropertyAttribute;
        }
    }
}

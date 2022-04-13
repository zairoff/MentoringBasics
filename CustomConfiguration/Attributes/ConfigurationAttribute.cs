using CustomConfiguration.Enum;
using System;

namespace CustomConfiguration.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigurationAttribute : Attribute
    {
        private readonly string _name;
        private readonly ProviderType _providerType;

        public ConfigurationAttribute(string name, ProviderType providerType)
        {
            _name = name;
            _providerType = providerType;
        }
    }
}

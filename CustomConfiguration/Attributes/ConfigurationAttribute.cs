using CustomConfiguration.Enum;
using System;

namespace CustomConfiguration.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigurationAttribute : Attribute
    {
        public string Path { get; private set; }
        public string Section { get; set; }
        public ProviderType ProviderType { get; private set; }

        public ConfigurationAttribute(string path, ProviderType providerType)
        {
            Path = path;
            ProviderType = providerType;
        }
    }
}

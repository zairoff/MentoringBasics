using CustomConfiguration.Enum;
using System;

namespace CustomConfiguration.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigurationAttribute : Attribute
    {
        public string Path { get; private set; }
        public string Section { get; private set; }
        public ProviderType ProviderType { get; private set; }

        public ConfigurationAttribute(string path, string section, ProviderType providerType)
        {
            Path = path;
            Section = section;
            ProviderType = providerType;
        }
    }
}

using System;

namespace CustomConfiguration.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationPropertyAttribute : Attribute
    {
        public string Key { get; private set; }

        public ConfigurationPropertyAttribute(string key)
        {
            Key = key;
        }
    }
}

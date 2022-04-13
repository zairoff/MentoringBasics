using System;

namespace CustomConfiguration.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationPropertyAttribute : Attribute
    {
        private readonly string _name;

        public ConfigurationPropertyAttribute(string name)
        {
            _name = name;
        }
    }
}

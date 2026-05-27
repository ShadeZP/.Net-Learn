using ConfigReflectionAbstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigReflectionDemo
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute : Attribute
    {
        public string SettingName { get; }
        public ProviderType ProviderType { get; }

        public ConfigurationItemAttribute(string settingName, ProviderType providerType)
        {
            SettingName = settingName;
            ProviderType = providerType;
        }
    }
}

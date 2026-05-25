using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConfigReflectionDemo
{
    public class ConfigurationComponentBase
    {
        private static ISettingsProvider GetProvider(ProviderType type)
        {
            return type switch
            {
                ProviderType.File => new FileConfigurationProvider(),
                ProviderType.ConfigurationManager => new ConfigurationManagerConfigurationProvider(),
                _ => throw new Exception("Unknown provider type")
            };
        }

        public void LoadSettings()
        {
            var props = this.GetType()
                .GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(ConfigurationItemAttribute)));

            var providerCache = new Dictionary<ProviderType, ISettingsProvider>();

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<ConfigurationItemAttribute>();

                if (!providerCache.TryGetValue(attr.ProviderType, out var provider))
                {
                    provider = GetProvider(attr.ProviderType);
                    providerCache[attr.ProviderType] = provider;
                }

                var value = provider.GetValue(attr.SettingName, prop.PropertyType);
                prop.SetValue(this, value);
            }
        }

        public void SaveSettings()
        {
            var props = this.GetType()
                .GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(ConfigurationItemAttribute)));

            var providerCache = new Dictionary<ProviderType, ISettingsProvider>();

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<ConfigurationItemAttribute>();

                if (!providerCache.TryGetValue(attr.ProviderType, out var provider))
                {
                    provider = GetProvider(attr.ProviderType);
                    providerCache[attr.ProviderType] = provider;
                }

                var value = prop.GetValue(this);
                provider.SetValue(attr.SettingName, value);
            }
        }
    }
}

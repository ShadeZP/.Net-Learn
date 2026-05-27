using ConfigReflectionAbstractions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ConfigReflectionDemo
{
    public class ConfigurationComponentBase
    {
        public void LoadSettings()
        {
            var props = this.GetType().GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(ConfigurationItemAttribute)));

            var providerCache = new Dictionary<ProviderType, ISettingsProvider>();

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<ConfigurationItemAttribute>();

                if (!providerCache.TryGetValue(attr.ProviderType, out var provider))
                {
                    provider = ProviderFactory.CreateProvider(attr.ProviderType);
                    providerCache[attr.ProviderType] = provider;
                }

                var value = provider.GetValue(attr.SettingName, prop.PropertyType);
                prop.SetValue(this, value);
            }
        }

        public void SaveSettings()
        {
            var props = this.GetType().GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(ConfigurationItemAttribute)));

            var providerCache = new Dictionary<ProviderType, ISettingsProvider>();

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<ConfigurationItemAttribute>();

                if (!providerCache.TryGetValue(attr.ProviderType, out var provider))
                {
                    provider = ProviderFactory.CreateProvider(attr.ProviderType);
                    providerCache[attr.ProviderType] = provider;
                }

                var value = prop.GetValue(this);
                provider.SetValue(attr.SettingName, value);
            }
        }
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigReflectionDemo
{
    public class ConfigurationManagerConfigurationProvider: ISettingsProvider
    {
        readonly IConfigurationRoot _config;
        public ConfigurationManagerConfigurationProvider()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }
        public object GetValue(string key, Type targetType)
        {
            var str = _config[key];
            if (str == null) return targetType.IsValueType ? Activator.CreateInstance(targetType) : null;
            if (targetType == typeof(string)) return str;
            if (targetType == typeof(int)) return int.Parse(str);
            if (targetType == typeof(float)) return float.Parse(str);
            if (targetType == typeof(TimeSpan)) return TimeSpan.Parse(str);
            throw new NotSupportedException();
        }
        public void SetValue(string key, object value)
        {
            var json = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("appsettings.json"))
                ?? [];
            json[key] = value.ToString();
            File.WriteAllText("appsettings.json", System.Text.Json.JsonSerializer.Serialize(json, new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));
        }
    }
}

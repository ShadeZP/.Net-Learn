using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigReflectionDemo
{
    public class FileConfigurationProvider : IConfigurationProvider
    {
        private readonly string _filePath = "settings.txt";
        private readonly Dictionary<string, string> _dict;

        public FileConfigurationProvider()
        {
            _dict = File.Exists(_filePath)
                ? File.ReadAllLines(_filePath)
                    .Where(l => l.Contains('='))
                    .Select(l => l.Split('='))
                    .ToDictionary(arr => arr[0], arr => arr[1])
                : [];
        }

        public object GetValue(string key, Type targetType)
        {
            if (!_dict.TryGetValue(key, out var str))
                return GetDefault(targetType);

            return ConvertValue(str, targetType);
        }

        public void SetValue(string key, object value)
        {
            _dict[key] = value.ToString();
            File.WriteAllLines(_filePath, _dict.Select(kv => $"{kv.Key}={kv.Value}"));
        }

        private object GetDefault(Type t) => t.IsValueType ? Activator.CreateInstance(t) : null;

        private object ConvertValue(string str, Type t)
        {
            if (t == typeof(string)) return str;
            if (t == typeof(int)) return int.Parse(str);
            if (t == typeof(float)) return float.Parse(str);
            if (t == typeof(TimeSpan)) return TimeSpan.Parse(str);
            throw new NotSupportedException("Type not supported");
        }
    }
}

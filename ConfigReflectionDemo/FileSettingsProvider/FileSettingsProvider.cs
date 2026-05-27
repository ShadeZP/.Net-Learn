using System.Globalization;
using ConfigReflectionAbstractions;

namespace FileSettingsProvider
{
    public class FileSettingsProvider: ISettingsProvider
    {
        private readonly string _filePath = "settings.txt";
        private readonly Dictionary<string, string> _dict;

        public FileSettingsProvider()
        {
            _dict = File.Exists(_filePath)
                ? File.ReadAllLines(_filePath)
                    .Where(l => l.Contains('='))
                    .Select(l => {
                        int idx = l.IndexOf('=');
                        return new[] { l[..idx], l[(idx + 1)..] };
                    })
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
            _dict[key] = Convert.ToString(value, CultureInfo.InvariantCulture);
            File.WriteAllLines(_filePath, _dict.Select(kv => $"{kv.Key}={kv.Value}"));
        }

        private object GetDefault(Type t) => t.IsValueType ? Activator.CreateInstance(t) : null;

        private object ConvertValue(string str, Type t)
        {
            if (t == typeof(string)) return str;
            if (t == typeof(int)) return int.Parse(str, CultureInfo.InvariantCulture);
            if (t == typeof(float)) return float.Parse(str, CultureInfo.InvariantCulture);
            if (t == typeof(TimeSpan)) return TimeSpan.Parse(str, CultureInfo.InvariantCulture);
            throw new NotSupportedException("Type not supported");
        }
    }
}

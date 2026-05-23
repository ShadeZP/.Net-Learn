using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigReflectionDemo
{
    public interface IConfigurationProvider
    {
        object GetValue(string key, Type targetType);
        void SetValue(string key, object value);
    }
}

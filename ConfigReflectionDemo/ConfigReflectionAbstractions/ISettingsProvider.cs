using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigReflectionAbstractions
{
    public interface ISettingsProvider
    {
        object GetValue(string key, Type targetType);
        void SetValue(string key, object value);
    }
}

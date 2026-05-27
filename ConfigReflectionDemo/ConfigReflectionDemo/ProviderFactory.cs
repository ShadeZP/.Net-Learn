using ConfigReflectionAbstractions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConfigReflectionDemo
{
    public class ProviderFactory
    {
        public static ISettingsProvider CreateProvider(ProviderType providerType)
        {
            string dllPath, typeName;

            switch (providerType)
            {
                case ProviderType.File:
                    dllPath = "FileSettingsProvider.dll";
                    typeName = "FileSettingsProvider.FileSettingsProvider";
                    break;
                case ProviderType.ConfigurationManager:
                    dllPath = "ConfigurationManagerSettingsProvider.dll";
                    typeName = "ConfigurationManagerSettingsProvider.ConfigurationManagerSettingsProvider";
                    break;
                default:
                    throw new NotSupportedException($"Provider '{providerType}' is not supported.");
            }

            if (!File.Exists(dllPath))
                throw new FileNotFoundException($"Can't find provider DLL: {dllPath}");

            var asm = Assembly.LoadFrom(dllPath);
            var type = asm.GetType(typeName);
            if (type == null)
                throw new Exception($"Type '{typeName}' not found in '{dllPath}'.");

            var instance = Activator.CreateInstance(type);

            return (ISettingsProvider)instance;
        }
    }
}

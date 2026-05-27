using ConfigReflectionAbstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigReflectionDemo
{
    public class DemoSettings : ConfigurationComponentBase
    {
        [ConfigurationItem("MyInt", ProviderType.File)]
        public int MyInt { get; set; }

        [ConfigurationItem("MyFloat", ProviderType.File)]
        public float MyFloat { get; set; }

        [ConfigurationItem("Greeting", ProviderType.ConfigurationManager)]
        public string Greeting { get; set; }

        [ConfigurationItem("Timeout", ProviderType.ConfigurationManager)]
        public TimeSpan Timeout { get; set; }
    }
}

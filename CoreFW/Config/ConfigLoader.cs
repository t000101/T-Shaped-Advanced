using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace CoreFW.Config
{
    public class ConfigLoader
    {
        public static readonly IConfigurationRoot config;

        static ConfigLoader()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appconfig.json", true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}

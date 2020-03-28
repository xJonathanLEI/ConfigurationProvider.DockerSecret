using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;

namespace ConfigurationProvider.DockerSecret
{
    public class DockerSecretConfigurationProvider : Microsoft.Extensions.Configuration.ConfigurationProvider
    {
        public override void Load()
        {
            // TODO: support custom secret path
            string defaultSecretPath;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                defaultSecretPath = "/run/secrets";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                defaultSecretPath = "C:\\ProgramData\\Docker\\secrets";
            }
            else
            {
                // Unsupported platform. Just fail silently by doing nothing
                return;
            }

            var secretFolder = new DirectoryInfo(defaultSecretPath);
            if (!secretFolder.Exists)
                return;

            Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var file in secretFolder.GetFiles())
                Data.Add(file.Name.Replace("__", ":"), File.ReadAllText(file.FullName));
        }
    }
}

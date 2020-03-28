using System;
using ConfigurationProvider.DockerSecret;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddDockerSecret(this IConfigurationBuilder builder)
        {
            return builder.Add(new DockerSecretConfigurationSource());
        }
    }
}
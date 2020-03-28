using Microsoft.Extensions.Configuration;

namespace ConfigurationProvider.DockerSecret
{
    public class DockerSecretConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new DockerSecretConfigurationProvider();
        }
    }
}

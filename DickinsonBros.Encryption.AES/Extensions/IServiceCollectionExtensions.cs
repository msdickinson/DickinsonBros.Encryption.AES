using DickinsonBros.Encryption.AES.Abstractions;
using DickinsonBros.Encryption.AES.Configurators;
using DickinsonBros.Encryption.AES.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace DickinsonBros.Encryption.AES.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAESEncryptionService<T>(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton(typeof(IAESEncryptionService<T>), typeof(AESEncryptionService<T>));
            serviceCollection.TryAddSingleton(typeof(IConfigureOptions<AESEncryptionServiceOptions<T>>), typeof(AESEncryptionServiceOptionsConfigurator<T>));

            return serviceCollection;
        }
    }
}

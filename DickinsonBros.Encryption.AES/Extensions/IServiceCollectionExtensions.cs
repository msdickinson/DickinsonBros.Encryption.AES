using DickinsonBros.Encryption.AES.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DickinsonBros.Encryption.AES.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAESEncryptionService<T>(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton(typeof(IAESEncryptionService<>), typeof(AESEncryptionService<>));

            return serviceCollection;
        }
    }
}

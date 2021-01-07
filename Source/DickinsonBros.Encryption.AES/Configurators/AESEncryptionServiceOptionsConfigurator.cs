using DickinsonBros.Encryption.AES.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DickinsonBros.Encryption.AES.Configurators
{
    public class AESEncryptionServiceOptionsConfigurator<T> : IConfigureOptions<AESEncryptionServiceOptions<T>> 
    where T : AESEncryptionServiceOptionsType
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public AESEncryptionServiceOptionsConfigurator(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        void IConfigureOptions<AESEncryptionServiceOptions<T>>.Configure(AESEncryptionServiceOptions<T> options)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var provider = scope.ServiceProvider;
            var configuration = provider.GetRequiredService<IConfiguration>();
            var path = $"{nameof(AESEncryptionServiceOptions<T>)}:{typeof(T).Name}";
            var accountAPITestsOptions = configuration.GetSection(path).Get<AESEncryptionServiceOptions<T>>();
            configuration.Bind(path, options);
        }
    }
}

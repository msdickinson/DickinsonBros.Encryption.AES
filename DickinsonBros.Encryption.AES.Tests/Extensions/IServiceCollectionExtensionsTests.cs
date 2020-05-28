using DickinsonBros.Encryption.AES.Abstractions;
using DickinsonBros.Encryption.AES.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DickinsonBros.Encryption.AES.Tests.Extensions
{
    [TestClass]
    public class IServiceCollectionExtensionsTests
    {
        [TestMethod]
        public void AddAESEncryptionService_Should_Succeed()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            serviceCollection.AddAESEncryptionService<object>();

            // Assert

            Assert.IsTrue(serviceCollection.Any(serviceDefinition => serviceDefinition.ServiceType == typeof(IAESEncryptionService<>) &&
                                           serviceDefinition.ImplementationType == typeof(AESEncryptionService<>) &&
                                           serviceDefinition.Lifetime == ServiceLifetime.Singleton));
        }
    }
}

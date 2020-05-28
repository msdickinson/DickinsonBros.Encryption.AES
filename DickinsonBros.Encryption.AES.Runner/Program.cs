﻿using DickinsonBros.Encryption.AES.Abstractions;
using DickinsonBros.Encryption.AES.Extensions;
using DickinsonBros.Encryption.AES.Models;
using DickinsonBros.Encryption.AES.Runner.Models;
using DickinsonBros.Encryption.AES.Runner.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DickinsonBros.Encryption.AES.Runner
{
    class Program
    {
        IConfiguration _configuration;
        async static Task Main()
        {
            await new Program().DoMain();
        }
        async Task DoMain()
        {
            try
            {
                using var applicationLifetime = new ApplicationLifetime();
                var services = InitializeDependencyInjection();
                ConfigureServices(services, applicationLifetime);

                using (var provider = services.BuildServiceProvider())
                {
                    var aesEncryptionService = provider.GetRequiredService<IAESEncryptionService<RunnerAESEncryptionServiceOptions>>();

                    var encryptedByteArray = aesEncryptionService.Encrypt("Sample123!");
                    var encryptedString = Convert.ToBase64String(encryptedByteArray);
                    var decryptedString = aesEncryptionService.Decrypt(encryptedByteArray);
                    Console.WriteLine(
                $@"Encrypted String
{ encryptedString }

Decrypted String
{ decryptedString }
");
                }
                applicationLifetime.StopApplication();
                await Task.CompletedTask.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("End...");
                Console.ReadKey();
            }
        }

        private void ConfigureServices(IServiceCollection services, ApplicationLifetime applicationLifetime)
        {
            services.AddOptions();
            services.AddLogging(config =>
            {
                config.AddConfiguration(_configuration.GetSection("Logging"));

                if (Environment.GetEnvironmentVariable("BUILD_CONFIGURATION") == "DEBUG")
                {
                    config.AddConsole();
                }
            });
            services.AddSingleton<IApplicationLifetime>(applicationLifetime);
            services.AddAESEncryptionService<RunnerAESEncryptionServiceOptions>();
            services.Configure<AESEncryptionServiceOptions<RunnerAESEncryptionServiceOptions>>(_configuration.GetSection(nameof(RunnerAESEncryptionServiceOptions)));
        }
        IServiceCollection InitializeDependencyInjection()
        {
            var aspnetCoreEnvironment = Environment.GetEnvironmentVariable("BUILD_CONFIGURATION");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{aspnetCoreEnvironment}.json", true);
            _configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddSingleton(_configuration);
            return services;
        }
    }
}


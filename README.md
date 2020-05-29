# DickinsonBros.Encryption.AES

<a href="https://www.nuget.org/packages/DickinsonBros.Encryption.AES/">
    <img src="https://img.shields.io/nuget/v/DickinsonBros.Encryption.AES">
</a>

Encrypt and decrypt strings

Features
* Advanced Encryption Standard based encryption
* Built with Generics allowing multiple configurations and instances concurrently.

<a href="https://dev.azure.com/marksamdickinson/DickinsonBros/_build?definitionScope=%5CDickinsonBros.Encryption.AES">Builds</a>

<h2>Example Usage</h2>

```C#
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
                }
```
    
    Encrypted String
    7BFFAPx56rGtAtB/LVBvdw==

    Decrypted String
    Sample123!

Example Runner Included in folder "DickinsonBros.Encryption.AES.Runner"

<h2>Setup</h2>

<h3>Get a Key and InitializationVector in Base64String Format</h3>

Example ones provided here:

  Key: "n1kNM3rmrsmacldt1XgIA3i2WlXTvR5aG3qK8Oq6ibA="
  InitializationVector: "BqjK8H2y67JBQ/4Zj/7HnQ=="

<h3>Add Nuget References</h3>

    https://www.nuget.org/packages/DickinsonBros.Encryption.AES/
    https://www.nuget.org/packages/DickinsonBros.Encryption.AES.Abstractions

<h3>Create class with base of AESEncryptionServiceOptions</h3>

```c#
public class RunnerAESEncryptionServiceOptions : AESEncryptionServiceOptions
{

};
```
<h3>Create Instance</h3>

```c#
var runnerAESEncryptionServiceOptions = new AESEncryptionServiceOptions<RunnerAESEncryptionServiceOptions>
{
    InitializationVector = "BqjK8H2y67JBQ/4Zj/7HnQ==",
    Key = "n1kNM3rmrsmacldt1XgIA3i2WlXTvR5aG3qK8Oq6ibA="
};
var options = Options.Create(runnerAESEncryptionServiceOptions);
var aesEncryptionService = new AESEncryptionService<RunnerAESEncryptionServiceOptions>(options);

```

<h3>Create Instance (With Dependency Injection)</h3>

<h4>Add appsettings.json File With Contents</h4>

 ```json  
{
  "RunnerAESEncryptionServiceOptions": {
    "Key": "n1kNM3rmrsmacldt1XgIA3i2WlXTvR5aG3qK8Oq6ibA=",
    "InitializationVector": "BqjK8H2y67JBQ/4Zj/7HnQ=="
  }
}
 ```    
<h4>Code</h4>

```c#

var serviceCollection = new ServiceCollection();

//Configure Options
var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false)

var configuration = builder.Build();
serviceCollection.AddOptions();
services.Configure<AESEncryptionServiceOptions<RunnerAESEncryptionServiceOptions>>(_configuration.GetSection(nameof(RunnerAESEncryptionServiceOptions)));

//Add Service
services.AddAESEncryptionService<RunnerAESEncryptionServiceOptions>();

//Build Service Provider 
using (var provider = services.BuildServiceProvider())
{
  var aesEncryptionService = provider.GetRequiredService<IAESEncryptionService<RunnerAESEncryptionServiceOptions>>();
}
```

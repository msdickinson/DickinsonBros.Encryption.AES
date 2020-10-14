# DickinsonBros.Encryption.AES

<a href="https://dev.azure.com/marksamdickinson/dickinsonbros/_build/latest?definitionId=49&amp;branchName=master"> <img alt="Azure DevOps builds (branch)" src="https://img.shields.io/azure-devops/build/marksamdickinson/DickinsonBros/49/master"> </a> <a href="https://dev.azure.com/marksamdickinson/dickinsonbros/_build/latest?definitionId=49&amp;branchName=master"> <img alt="Azure DevOps coverage (branch)" src="https://img.shields.io/azure-devops/coverage/marksamdickinson/dickinsonbros/49/master"> </a><a href="https://dev.azure.com/marksamdickinson/DickinsonBros/_release?_a=releases&view=mine&definitionId=23"> <img alt="Azure DevOps releases" src="https://img.shields.io/azure-devops/release/marksamdickinson/b5a46403-83bb-4d18-987f-81b0483ef43e/23/24"> </a><a href="https://www.nuget.org/packages/DickinsonBros.Encryption.AES/"><img src="https://img.shields.io/nuget/v/DickinsonBros.Encryption.AES"></a>

Encrypt and decrypt strings

Features
* Advanced Encryption Standard based encryption
* Built with Generics allowing multiple configurations and instances concurrently.

<h2>Example Usage</h2>

```C#
var encryptedString = aesEncryptionService.Encrypt("Sample123!");
var decryptedString = aesEncryptionService.Decrypt(encryptedString);
var encryptedByteArray = aesEncryptionService.EncryptToByteArray("Sample123!");
var decryptedStringFromByteArray = aesEncryptionService.Decrypt(encryptedByteArray);
Console.WriteLine(
$@"Encrypted String
{ encryptedString }

Decrypted string
{ decryptedString }

Encrypted To ByteArray
{  Encoding.UTF8.GetString(encryptedByteArray) }

Decrypted String
{ decryptedStringFromByteArray }
");
```
    
    Encrypted String
    7BFFAPx56rGtAtB/LVBvdw==

    Decrypted string
    Sample123!

    Encrypted To ByteArray
    ?E ?y??-Pow

    Decrypted String
    Sample123!

[Sample Runner](https://github.com/msdickinson/DickinsonBros.Encryption.AES/tree/master/DickinsonBros.Encryption.AES.Runner)

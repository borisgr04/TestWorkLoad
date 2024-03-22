using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using TestWorkLoad;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string keyVaultName = "KV-AEU-ECP-DEV-TRUE";
string clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
string tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
string clientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");

Console.WriteLine("Imprimiendo Key vault Name " + keyVaultName);
Console.WriteLine(clientId);
Console.WriteLine(tenantId);
Console.WriteLine(clientSecret);

var kvUri = "https://" + keyVaultName + ".vault.azure.net";

var client = new SecretClient(
                new Uri(kvUri),
                new DefaultAzureCredential());

Console.WriteLine("Conexión exitosa a KeyVault");

var secret = await client.GetSecretAsync("MsiSqlConnectionString");

Console.WriteLine("Test Azure KeyVault");
Console.WriteLine(secret.Value.Value);

try
{
    var bus = new ServiceBusProxy();

    Console.WriteLine("Test Azure Service Bus");
    await bus.TestAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Test Azure Service Bus {ex.Message}, {ex.StackTrace} ");
}


try
{
    var blob = new BlobStorageProxy();

    Console.WriteLine("Test Azure Blob Service ");
    await blob.TestAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Test Azure Blob {ex.Message}, {ex.StackTrace} ");
}

//TableStorage

try
{
    var sql = new SqlServerProxy();

    Console.WriteLine("Test Azure SqlServer Service ");
    await sql.TestAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Test Azure SqlServer {ex.Message}, {ex.StackTrace} ");
}




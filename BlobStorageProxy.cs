using Azure;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkLoad
{
    internal class BlobStorageProxy
    {
        public async Task TestAsync()
        {
            var blobServiceClient = new BlobServiceClient(
            new Uri("https://saaeuecpdevtrue.blob.core.windows.net"),
            new DefaultAzureCredential());

            await CreateSampleContainerAsync(blobServiceClient);


        }

        //-------------------------------------------------
        // Create a container
        //-------------------------------------------------
        private static async Task<BlobContainerClient> CreateSampleContainerAsync(BlobServiceClient blobServiceClient)
        {
            // Name the sample container based on new GUID to ensure uniqueness.
            // The container name must be lowercase.
            string containerName = "container-" + Guid.NewGuid();

            try
            {
                // Create the container
                BlobContainerClient container = await blobServiceClient.CreateBlobContainerAsync(containerName);

                if (await container.ExistsAsync())
                {
                    Console.WriteLine("Conexión exitosa a Storage");
                    Console.WriteLine("Created container {0}", container.Name);
                    return container;
                }
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine("HTTP error code {0}: {1}",
                                    e.Status, e.ErrorCode);
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}

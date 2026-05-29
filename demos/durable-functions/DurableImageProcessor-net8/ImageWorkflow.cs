using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;

namespace DurableImageProcessor_net8;

public class ImageWorkflow
{
    [Function("ImageWorkflow")]
    public async Task Run([OrchestrationTrigger] TaskOrchestrationContext context)
    {
        var blobName = context.GetInput<string>();
        await context.CallActivityAsync("ValidateImage", blobName);
        await context.CallActivityAsync("GenerateThumbnail", blobName);
        await context.CallActivityAsync("SaveMetadata", blobName);
    }
}
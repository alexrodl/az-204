using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask.Client;

namespace DurableImageProcessor;

public class StartImageWorkflow
{
    [Function("StartImageWorkflow")]
    public async Task Run([QueueTrigger("images", Connection = "ImagesStorage")] string blobName, [DurableClient] DurableTaskClient client)
    {
        await client.ScheduleNewOrchestrationInstanceAsync("ImageWorkflow", blobName);

        Console.WriteLine($"Workflow started for {blobName}");
    }
}
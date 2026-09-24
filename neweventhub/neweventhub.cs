using System;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace neweventhub;
public class neweventhub
{
    private readonly ILogger<neweventhub> _logger;

    public neweventhub(ILogger<neweventhub> logger)
    {
        _logger = logger;
    }

    [Function(nameof(neweventhub))]
    public void Run([EventHubTrigger("samples-workitems", Connection = "EventHubConnectionString")] EventData[] events)
    {
        foreach (EventData @event in events)
        {
            _logger.LogInformation("Event Body: {body}", @event.Body);
            _logger.LogInformation("Event Content-Type: {contentType}", @event.ContentType);
        }
    }
}

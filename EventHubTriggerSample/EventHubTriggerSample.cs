using System;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EventHubTriggerSample;
public class EventHubTriggerSample
{
    private readonly ILogger<EventHubTriggerSample> _logger;

    public EventHubTriggerSample(ILogger<EventHubTriggerSample> logger)
    {
        _logger = logger;
    }

    [Function(nameof(EventHubTriggerSample))]
    public void Run([EventHubTrigger("samples-workitems", Connection = "")] EventData[] events)
    {
        foreach (EventData @event in events)
        {
            _logger.LogInformation("Event Body: {body}", @event.Body);
            _logger.LogInformation("Event Content-Type: {contentType}", @event.ContentType);
        }
    }
}

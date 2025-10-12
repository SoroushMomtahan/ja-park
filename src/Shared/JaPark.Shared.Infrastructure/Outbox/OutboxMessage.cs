﻿namespace LearnTop.Shared.Infrastructure.Outbox;

public class OutboxMessage
{
    public Guid Id { get; init; }

    public string Type { get; init; }

    public string Content { get; init; }

    public DateTime OccurredOnUtc { get; init; }

    public DateTime? ProcessedOnUtc { get; private set; }

    public string? Error { get; private set; }

    public void AddProcessedOn(DateTime processedOnUtc)
    {
        ProcessedOnUtc = processedOnUtc;
    }
    public void AddError(string? error)
    {
        Error = error;
    }
}

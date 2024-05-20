using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public record Room
{
    [JsonPropertyName("roomId")]
    public string? RoomId { get; init; }

    [JsonPropertyName("roomName")]
    public string? RoomName { get; init; }

    [JsonPropertyName("capacity")]
    public int Capacity { get; init; }

    public override string ToString()
    {
        return $"RoomId: {RoomId}, RoomName: {RoomName}, Capacity: {Capacity}";
    }
}
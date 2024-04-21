using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public record LogRecord
{

    public string? Message { get; set; }

    public DateTime Timestamp { get; set; }

}
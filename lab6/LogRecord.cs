using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public record LogRecord
{

    public DateTime TimeStamp { get; init; }

    public string Message { get; init; }
    
    public LogRecord(DateTime timeStamp, string message)
    {
        TimeStamp = timeStamp;
        Message = message;
    }

    public override string ToString()
    {
        return $"Time: {TimeStamp} \n Message: {Message} \n";
    }

}
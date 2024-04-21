using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class FileLogger : ILogger
{
    public void Log(LogRecord log)
    {
        string jsonString = JsonSerializer.Serialize(log);
        File.AppendAllText("log.json", jsonString + Environment.NewLine);
    }

}

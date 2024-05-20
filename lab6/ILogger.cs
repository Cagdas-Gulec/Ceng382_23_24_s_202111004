using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class ILogger
{
    public void Log(string message)
    {
        LogRecord logRecord = new LogRecord(new DateTime(2024, 10, 21, 17, 25, 32), message);
        string jsonString = JsonSerializer.Serialize(logRecord.ToString(), new JsonSerializerOptions { WriteIndented = true });
        File.AppendAllText("LogData.json", jsonString + Environment.NewLine);
    }
}

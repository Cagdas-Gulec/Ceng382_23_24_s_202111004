using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;

public class LogHandler
{

    public void handleLog(string message)
    {
        LogRecord logRecord = new LogRecord(DateTime.Now, message);
        string jsonString = JsonSerializer.Serialize(logRecord);
        using (StreamWriter writer = new StreamWriter("LogData.json", append: true))
        {
            writer.WriteLine(jsonString);
        }
    }
    
}

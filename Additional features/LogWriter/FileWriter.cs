using System.IO;
using System.Text;

public class FileWriter
{
    private string _filePath;
    private const string _logFormat = "[{0}]:{1}\r";

    public FileWriter(string filePath)
    {
        _filePath = filePath + "/log.log";
    }

    public void Write(LogMessage message)
    {
        var MessageToWrite = string.Format(_logFormat, message.Type, message.Message);

        using (FileStream fs = File.Open(_filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
        {
            var bytes = Encoding.UTF8.GetBytes(MessageToWrite);
            fs.Write(bytes, 0, bytes.Length);
        }
    }

    public void Clear()
    {
        FileStream fs = File.Open(_filePath, FileMode.Open, FileAccess.ReadWrite);
        fs.SetLength(0);
    }
}

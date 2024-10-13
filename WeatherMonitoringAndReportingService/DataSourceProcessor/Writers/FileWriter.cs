namespace WeatherMonitoringAndReportingService.DataSourceProcessor.Writers;

public class FileWriter : IFileWriter
{

    void IFileWriter.WriteFile(string path, string content)
    {
        File.WriteAllText(path, content);
    }
}
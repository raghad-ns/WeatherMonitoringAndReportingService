namespace WeatherMonitoringAndReportingService.DataSourceProcessor.Writers;

public interface IFileWriter
{
    void WriteFile(string path, string content);
}
using WeatherMonitoringAndReportingService.AppSettings;
using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.DataSourceProcessor.Readers;
using WeatherMonitoringAndReportingService.DataSourceProcessor.Serializers;
using WeatherMonitoringAndReportingService.DataSourceProcessor.Writers;

namespace WeatherMonitoringAndReportingService.DataSourceProcessor;

public class JSONFileProcessor : IDataSourceProcessor
{
    private readonly IFileWriter _fileWriter;
    private readonly IFileSerializer _fileSerializer;
    private readonly IFileReader _fileReader;
    
    public JSONFileProcessor(IFileWriter fileWriter, IFileSerializer fileSerializer, IFileReader fileReader)
    {
        _fileWriter = fileWriter;
        _fileSerializer = fileSerializer;
        _fileReader = fileReader;
    }

    public void Add(string name, WeatherConfigurationModel data, string? path)
    {
        path ??= AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

        // 1. Read file
        var currentData = _fileReader.ReadFile(path);

        // 2. Add 
        currentData.Add(name, data);

        // Serialize Dictionary
        var serializedData = _fileSerializer.Serialize(currentData);

        // Write file
        _fileWriter.WriteFile(serializedData, path);
    }

    public void Remove(string name, string? path)
    {
        path ??= AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;
        // 1. Read file
        var currentData = _fileReader.ReadFile(path);

        // 2. Remove 
        currentData.Remove(name);

        // Serialize Dictionary
        var serializedData = _fileSerializer.Serialize(currentData);

        // Write file
        _fileWriter.WriteFile(serializedData, path);
    }

    public void Update(string name, WeatherConfigurationModel data, string? path)
    {
        path ??= AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

        // 1. Read file
        var currentData = _fileReader.ReadFile(path);

        // 2. Update 
        currentData[name] = data;

        // Serialize Dictionary
        var serializedData = _fileSerializer.Serialize(currentData);

        // Write file
        _fileWriter.WriteFile(serializedData, path);
    }

}
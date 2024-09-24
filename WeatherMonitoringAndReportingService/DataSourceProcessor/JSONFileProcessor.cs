using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.AppSettings;
using WeatherMonitoringAndReportingService.Config;

namespace WeatherMonitoringAndReportingService.DataSourceProcessor;

public class JSONFileProcessor : IDataSourceProcessor
{
    public void Add(string name, WeatherConfigurationModel data, string path)
    {
        path ??= AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

        // 1. Read file
        var currentData = ReadFile(path);

        // 2. Add 
        currentData.Add(name, data);

        // Serialize Dictionary
        var serializedData = Serialize(currentData);

        // Write file
        WriteFile(serializedData, path);
    }

    public Dictionary<string, WeatherConfigurationModel> ReadFile(string? path)
    {
        string jsonString = File.ReadAllText(path ?? AppSettingsInitializer.AppSettingsInstance().ConfigFilePath);
        var botsSettings = JsonSerializer.Deserialize<Dictionary<string, WeatherConfigurationModel>>(jsonString);

        return botsSettings;
    }

    public void Remove(string name, string? path)
    {
        path ??= AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;
        // 1. Read file
        var currentData = ReadFile(path);

        // 2. Remove 
        currentData.Remove(name);

        // Serialize Dictionary
        var serializedData = Serialize(currentData);

        // Write file
        WriteFile(serializedData, path);
    }

    public void Update(string name, WeatherConfigurationModel data, string? path)
    {

        path ??= AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

        // 1. Read file
        var currentData = ReadFile(path);

        // 2. Update 
        currentData[name] = data;

        // Serialize Dictionary
        var serializedData = Serialize(currentData);

        // Write file
        WriteFile(serializedData, path);
    }

    private string Serialize(Dictionary<string, WeatherConfigurationModel> data)
    {
        return JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
    }

    private void WriteFile(string data, string path)
    {
        File.WriteAllText(path, data);
    }
}

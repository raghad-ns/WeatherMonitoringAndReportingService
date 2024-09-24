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
    public void Add(string name, WeatherConfigurationModel model, string path)
    {
        throw new NotImplementedException();
    }

    public Dictionary<string,WeatherConfigurationModel> ReadFile(string? path)
    {
        string jsonString = File.ReadAllText(path ?? AppSettingsInitializer.AppSettingsInstance().ConfigFilePath);
        var botsSettings = JsonSerializer.Deserialize<Dictionary<string, WeatherConfigurationModel>>(jsonString);

        return botsSettings;
    }

    public void Remove(string name, string path)
    {
        throw new NotImplementedException();
    }

    public void Update(string name, WeatherConfigurationModel model, string path)
    {
        throw new NotImplementedException();
    }
}

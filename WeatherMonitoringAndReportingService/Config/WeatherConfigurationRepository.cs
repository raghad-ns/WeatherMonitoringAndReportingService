using WeatherMonitoringAndReportingService.AppSettings;
using WeatherMonitoringAndReportingService.DataSourceProcessor;
using WeatherMonitoringAndReportingService.DataSourceProcessor.Readers;

namespace WeatherMonitoringAndReportingService.Config;

public class WeatherConfigurationRepository: IWeatherConfigurationRepository
{
    private readonly IDataSourceProcessor _dataSourceProcessor;
    private readonly IFileReader _reader;
    private readonly Dictionary<string, WeatherConfigurationModel> _weatherConfigurations;
    private readonly string _configFilePath = AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

    public WeatherConfigurationRepository(IDataSourceProcessor dataSourceProcessor, IFileReader reader) {
        _dataSourceProcessor = dataSourceProcessor;
        _reader = reader;
        _weatherConfigurations = _reader.ReadFile(_configFilePath);
    }

    public void AddBotConfiguration(string name, WeatherConfigurationModel configuration)
    {
        _weatherConfigurations.Add(name, configuration);
        _dataSourceProcessor.Add(name, configuration, _configFilePath);
    }

    public void RemoveBotConfiguration(string name)
    {
        _weatherConfigurations.Remove(name);
        _dataSourceProcessor.Remove(name, _configFilePath);
    }

    public void UpdateBotConfiguration(string name, WeatherConfigurationModel configuration)
    {
        _weatherConfigurations[name] = configuration;
        _dataSourceProcessor.Update(name, configuration, _configFilePath);
    }

    public WeatherConfigurationModel GetBotConfiguration(string name) { return _weatherConfigurations[name]; }
}
﻿using WeatherMonitoringAndReportingService.Config;

namespace WeatherMonitoringAndReportingService.DataSourceProcessor;

public interface IDataSourceProcessor
{
    public Dictionary<string, WeatherConfigurationModel> ReadFile(string? path);
    public void Add(string name, WeatherConfigurationModel model, string? path);
    public void Remove(string name, string? path);
    public void Update(string name, WeatherConfigurationModel model, string? path);
}
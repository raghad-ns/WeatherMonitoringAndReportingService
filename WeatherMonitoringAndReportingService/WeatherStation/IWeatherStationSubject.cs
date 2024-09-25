using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.WeatherStation;

public interface IWeatherStationSubject
{
    public void Attach(IBot bot);
    public void Detach(IBot bot);
    public void Notify(WeatherDetailsModel state);
}
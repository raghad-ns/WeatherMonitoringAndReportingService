using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.Bots;

namespace WeatherMonitoringAndReportingService.WeatherStation;

public interface IWeatherStationSubject
{
    public void Attach(IBot bot);
    public void Detach(IBot bot);
    public void Notify(string state);
}

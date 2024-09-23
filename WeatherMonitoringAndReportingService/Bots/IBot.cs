using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.Bots;

public interface IBot
{
    public void UpdateConfiguration(string state);
}

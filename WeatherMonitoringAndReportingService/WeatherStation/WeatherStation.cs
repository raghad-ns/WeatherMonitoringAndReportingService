﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.WeatherStation
{
    public class WeatherStation : IWeatherStationSubject
    {
        private List<IBot> _bots = new();

        public void Attach(IBot bot) => _bots.Add(bot);
        public void Detach(IBot bot) => _bots.Remove(bot);

        public void Notify(WeatherDetailsModel state)
        {
            foreach (IBot bot in _bots)
            {
                bot.UpdateConfiguration(state);
            }
        }
    }
}

using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.WeatherStation
{
    public class WeatherStation : IWeatherStationSubject
    {
        private List<IBot> _bots = [];
        
        public WeatherStation(List<IBot> bots) { 
            _bots = bots;
        }
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
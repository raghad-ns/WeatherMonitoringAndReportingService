using System.Text;
using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.DataSourceProcessor;
using WeatherMonitoringAndReportingService.InputConversion;

namespace WeatherMonitoringAndReportingService
{
    public class Program
    {
        private static WeatherStation.WeatherStation _weatherStation = new();
        static void Main(string[] args)
        {
            InitializeApp();

            Console.WriteLine("Enter weather status (type 'STOP' to finish):");

            StringBuilder userInput = new StringBuilder();
            string line;

            // Keep reading input until the user types "STOP"
            while ((line = Console.ReadLine()) != "STOP")
            {
                userInput.AppendLine(line);
            }

            _weatherStation.Notify(JSONToWeatherDetailsAdapter.ToWeatherDetailsAdapter(userInput.ToString()));
        }

        public static void InitializeApp()
        {
            WeatherConfigurationService weatherConfigurationService = new(
                new WeatherConfigurationRepository(
                    new JSONFileProcessor()));

            _weatherStation.Attach(new RainBot(weatherConfigurationService));
            _weatherStation.Attach(new SnowBot(weatherConfigurationService));
            _weatherStation.Attach(new SunBot(weatherConfigurationService));
        }
    }
}

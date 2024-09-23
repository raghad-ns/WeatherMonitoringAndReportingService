using System.Text;
using WeatherMonitoringAndReportingService.InputConversion;

namespace WeatherMonitoringAndReportingService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter weather status (type 'STOP' to finish):");

            StringBuilder userInput = new StringBuilder();
            string line;

            // Keep reading input until the user types "STOP"
            while ((line = Console.ReadLine()) != "STOP")
            {
                userInput.AppendLine(line);
            }

            Console.WriteLine(JSONToWeatherDetailsAdapter.ToWeatherDetailsAdapter(userInput.ToString()).Location);
        }
    }
}

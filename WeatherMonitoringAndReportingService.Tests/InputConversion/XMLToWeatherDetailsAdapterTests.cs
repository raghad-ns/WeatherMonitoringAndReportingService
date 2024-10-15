using AutoFixture;
using FluentAssertions;
using WeatherMonitoringAndReportingService.InputConversion;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.Tests.InputConversion;

public class XMLToWeatherDetailsAdapterTests
{
    private readonly Fixture _fixture;

    public XMLToWeatherDetailsAdapterTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void ToWeatherDetailsAdapter_ShouldReturnWeatherDetailsModel()
    {
        string city = "City";
        double temperature = 25.0;
        double humidity = 70.0;
        // Arrange
        var xmlInput = @$"<WeatherData>
                            <Location>{city}</Location>
                            <Temperature>{temperature}</Temperature>
                            <Humidity>{humidity}</Humidity>
                        </WeatherData>";
        var expectedWeatherDetails = new WeatherDetailsModel
        {
            Location = city,
            Temperature = temperature,
            Humidity = humidity
        };

        // Act
        var weatherDetailsMode = XMLToWeatherDetailsAdapter.ToWeatherDetailsAdapter(xmlInput);

        // Assert
        weatherDetailsMode.Should().BeEquivalentTo(expectedWeatherDetails);
    }

    [Fact]
    public void ToWeatherDetailsAdapter_InvalidXMLInput_ShouldThrowInvalidOperationException()
    {
        // Arrange

        // Act
        Action weatherDetails = () => XMLToWeatherDetailsAdapter.ToWeatherDetailsAdapter(_fixture.Create<string>());

        // Assert
        weatherDetails.Should().Throw<InvalidOperationException>();
    }
}
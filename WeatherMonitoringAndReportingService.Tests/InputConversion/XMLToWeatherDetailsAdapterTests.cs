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
        // Arrange
        var xmlInput = @"<WeatherData>
                            <Location>City Name</Location>
                            <Temperature>23.0</Temperature>
                            <Humidity>85.0</Humidity>
                        </WeatherData>";

        // Act
        var weatherDetailsMode = XMLToWeatherDetailsAdapter.ToWeatherDetailsAdapter(xmlInput);

        // Assert
        weatherDetailsMode.Should().BeOfType<WeatherDetailsModel>();
    }

    [Fact]
    public void ToWeatherDetailsAdapter_Fail_ThrowException_WhenInputIsInvalidXML()
    {
        // Arrange

        // Act
        Action weatherDetails = () => XMLToWeatherDetailsAdapter.ToWeatherDetailsAdapter(_fixture.Create<string>());

        // Assert
        weatherDetails.Should().Throw<InvalidOperationException>();
    }
}
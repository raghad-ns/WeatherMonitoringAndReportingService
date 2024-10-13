// For observer pattern: this is the concrete subject class unit tests
using AutoFixture;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.DataSourceProcessor;
using WeatherMonitoringAndReportingService.WeatherDetails;

namespace WeatherMonitoringAndReportingService.Tests.WeatherStation;

public class WeatherStationTests
{
    private readonly WeatherMonitoringAndReportingService.WeatherStation.WeatherStation _weatherStation;
    private readonly Fixture _fixture;
    private readonly List<IBot> _observerBots;
    private readonly Mock<IBot> _observerBotMocks;
    private readonly RainBot _rainBot;

    public WeatherStationTests()
    {
        _observerBots = new List<IBot>();
        _observerBotMocks= new Mock<IBot>();
        _observerBots.Add(_observerBotMocks.Object);

        _weatherStation = new(_observerBots);
        _fixture = new Fixture();

        var mockJsonProcessor = new Mock<JSONFileProcessor>();
        var mockRepository = new Mock<WeatherConfigurationRepository>(mockJsonProcessor.Object);
        var mockService = new Mock<WeatherConfigurationService>(mockRepository.Object);
        _rainBot = new RainBot(mockService.Object);
    }

    [Fact]
    public void Attach_ShouldAddBotSuccessfully()
    {
        // Arrange

        // Act
        _weatherStation.Attach(_rainBot);

        // Assert
        _observerBots.Count.Should().Be(2);
    }

    [Fact]
    public void Detach_ShouldRemoveBotSuccessfully()
    {
        // Arrange

        // Act
        _weatherStation.Detach(_rainBot);

        // Assert
        _observerBots.Count.Should().Be(1);
    }

    [Fact]
    public void Notify_ShouldNotifyAllObservers()
    {
        // Arrange
        var weatherState = _fixture.Create<WeatherDetailsModel>();

        // Act
        _weatherStation.Notify(weatherState);

        // Assert
        _observerBotMocks.Verify(bot => bot.UpdateConfiguration(It.IsAny<WeatherDetailsModel>()));
    }
}
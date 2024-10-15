// For observer pattern: this is the concrete subject class unit tests
using AutoFixture;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.DataSourceProcessor;
using WeatherMonitoringAndReportingService.DataSourceProcessor.Readers;
using WeatherMonitoringAndReportingService.DataSourceProcessor.Serializers;
using WeatherMonitoringAndReportingService.DataSourceProcessor.Writers;
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
        _observerBotMocks = new Mock<IBot>();
        _observerBots.Add(_observerBotMocks.Object);

        _weatherStation = new(_observerBots);
        _fixture = new Fixture();

        var writerMock = new Mock<IFileWriter>();
        var readerMock = new Mock<IFileReader>();
        var serializerMock = new Mock<IFileSerializer>();

        var mockJsonProcessor = new Mock<JSONFileProcessor>(writerMock.Object, serializerMock.Object, readerMock.Object);
        var mockRepository = new Mock<WeatherConfigurationRepository>(mockJsonProcessor.Object, readerMock.Object);
        var mockService = new Mock<WeatherConfigurationService>(mockRepository.Object);
        _rainBot = new RainBot(mockService.Object);
    }

    [Fact]
    public void Attach_ShouldAddBotSuccessfully()
    {
        // Arrange
        var expectedObservers = new List<IBot> { _observerBotMocks.Object, _rainBot};

        // Act
        _weatherStation.Attach(_rainBot);

        // Assert
        _observerBots.Should().BeEquivalentTo(expectedObservers);
    }

    [Fact]
    public void Detach_ShouldRemoveBotSuccessfully()
    {
        // Arrange
        var expectedObservers = new List<IBot> { _observerBotMocks.Object };

        // Act
        _weatherStation.Detach(_rainBot);

        // Assert
        _observerBots.Should().BeEquivalentTo(expectedObservers);
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
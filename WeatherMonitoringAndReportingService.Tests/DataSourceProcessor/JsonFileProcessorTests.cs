using AutoFixture;
using FluentAssertions.Execution;
using Moq;
using WeatherMonitoringAndReportingService.AppSettings;
using WeatherMonitoringAndReportingService.Config;
using WeatherMonitoringAndReportingService.DataSourceProcessor;
using WeatherMonitoringAndReportingService.DataSourceProcessor.Readers;
using WeatherMonitoringAndReportingService.DataSourceProcessor.Serializers;
using WeatherMonitoringAndReportingService.DataSourceProcessor.Writers;

namespace WeatherMonitoringAndReportingService.Tests.DataSourceProcessor;

public class JsonFileProcessorTests
{
    private readonly Mock<IFileWriter> _jsonWriterMock = new();
    private readonly Mock<IFileSerializer> _jsonSerializerMock = new();
    private readonly Mock<IFileReader> _jsonReaderMock = new();

    private readonly Fixture _fixture = new();

    private readonly JSONFileProcessor _jsonProcessor;

    public JsonFileProcessorTests()
    {
        _jsonProcessor = new JSONFileProcessor(_jsonWriterMock.Object, _jsonSerializerMock.Object, _jsonReaderMock.Object);

        SetupCommonMocks();
    }

    private void SetupCommonMocks()
    {
        _jsonSerializerMock
            .Setup(serializer => serializer.Serialize(It.IsAny<Dictionary<string, WeatherConfigurationModel>>()))
            .Returns(_fixture.Create<string>());

        _jsonReaderMock
            .Setup(reader => reader.ReadFile(It.IsAny<string>()))
            .Returns(new Dictionary<string, WeatherConfigurationModel>());
    }

    [Fact]
    public void Add_ShouldLoadNewBotInMemoryAndWriteNewBotToConfigurationFile()
    {
        // Arrange
        var name = "RainBot";
        var weatherConfigurationModel = _fixture.Create<WeatherConfigurationModel>();
        var path = AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

        // Act
        _jsonProcessor.Add(name, new WeatherConfigurationModel(), path);

        // Assert
        using (new AssertionScope())
        {
            _jsonReaderMock.Verify(readerMock => readerMock.ReadFile(It.IsAny<string>()), Times.Once);
            _jsonSerializerMock.Verify(
                serializerMock => serializerMock.Serialize(It.IsAny<Dictionary<string, WeatherConfigurationModel>>()),
                Times.Once);
            _jsonWriterMock.Verify(
                writerMock => writerMock.WriteFile(It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }
    }

    [Fact]
    public void Update_ShouldUpdateBotDetailsAndWriteDetailsBackToConfigurationFile()
    {
        // Arrange
        const string name = "RainBot";
        var path = AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

        // Act
        _jsonProcessor.Update(name, new WeatherConfigurationModel(), path);

        // Assert
        using (new AssertionScope())
        {
            _jsonReaderMock.Verify(readerMock => readerMock.ReadFile(It.IsAny<string>()), Times.Once);
            _jsonSerializerMock.Verify(
                serializerMock => serializerMock.Serialize(It.IsAny<Dictionary<string, WeatherConfigurationModel>>()),
                Times.Once);
            _jsonWriterMock.Verify(
                writerMock => writerMock.WriteFile(It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }
    }

    [Fact]
    public void Remove_ShouldRemoveBotFromMemoryAndFromConfigurationFile()
    {
        // Arrange
        const string name = "RainBot";
        var path = AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

        // Act
        _jsonProcessor.Remove(name, path);

        // Assert
        using (new AssertionScope())
        {
            _jsonReaderMock.Verify(readerMock => readerMock.ReadFile(It.IsAny<string>()), Times.Once);
            _jsonSerializerMock.Verify(
                serializerMock => serializerMock.Serialize(It.IsAny<Dictionary<string, WeatherConfigurationModel>>()),
                Times.Once);
            _jsonWriterMock.Verify(
                writerMock => writerMock.WriteFile(It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }
    }
}
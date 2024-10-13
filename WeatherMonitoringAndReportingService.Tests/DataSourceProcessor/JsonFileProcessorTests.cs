using AutoFixture;
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
    private readonly Mock<IFileWriter> _jsonWriterMock;
    private readonly Mock<IFileSerializer> _jsonSerializerMock;
    private readonly Mock<IFileReader> _jsonReaderMock;
    private readonly JSONFileProcessor _jsonProcessor;
    private readonly Fixture _fixture;

    public JsonFileProcessorTests()
    {
        _fixture = new Fixture();
        _jsonWriterMock = new Mock<IFileWriter>();
        _jsonSerializerMock = new Mock<IFileSerializer>();
        _jsonReaderMock = new Mock<IFileReader>();
        _jsonProcessor = new JSONFileProcessor(_jsonWriterMock.Object, _jsonSerializerMock.Object, _jsonReaderMock.Object);

        _jsonSerializerMock
            .Setup(serializer => serializer.Serialize(It.IsAny<Dictionary<string, WeatherConfigurationModel>>()))
            .Returns(_fixture.Create<string>());
        _jsonReaderMock
            .Setup(reader => reader.ReadFile(It.IsAny<string>()))
            .Returns(new Dictionary<string, WeatherConfigurationModel>());
    }

    [Fact]
    public void Add_ShouldAddFileAddingNewLine()
    {
        // Arrange
        var name = "RainBot";
        var weatherConfigurationModel = _fixture.Create<WeatherConfigurationModel>();
        var path = AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

        // Act
        _jsonProcessor.Add(name, new WeatherConfigurationModel(), path);

        // Assert
        _jsonReaderMock.Verify(readerMock => readerMock.ReadFile(It.IsAny<string>()), Times.Once);
        _jsonSerializerMock.Verify(
            serializerMock => serializerMock.Serialize(It.IsAny<Dictionary<string, WeatherConfigurationModel>>()),
            Times.Once);
        _jsonWriterMock.Verify(
            writerMock => writerMock.WriteFile(It.IsAny<string>(), It.IsAny<string>()),
            Times.Once);
    }

    [Fact]
    public void Update_ShouldUpdateFileAddingNewLine()
    {
        // Arrange
        var name = "RainBot";
        var weatherConfigurationModel = _fixture.Create<WeatherConfigurationModel>();
        var path = AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

        // Act
        _jsonProcessor.Update(name, new WeatherConfigurationModel(), path);

        // Assert
        _jsonReaderMock.Verify(readerMock => readerMock.ReadFile(It.IsAny<string>()), Times.Once);
        _jsonSerializerMock.Verify(
            serializerMock => serializerMock.Serialize(It.IsAny<Dictionary<string, WeatherConfigurationModel>>()),
            Times.Once);
        _jsonWriterMock.Verify(
            writerMock => writerMock.WriteFile(It.IsAny<string>(), It.IsAny<string>()),
            Times.Once);
    }

    [Fact]
    public void Remove_ShouldRemoveFileAddingNewLine()
    {
        // Arrange
        var name = "RainBot";
        var weatherConfigurationModel = _fixture.Create<WeatherConfigurationModel>();
        var path = AppSettingsInitializer.AppSettingsInstance().ConfigFilePath;

        // Act
        _jsonProcessor.Remove(name, path);

        // Assert
        _jsonReaderMock.Verify(readerMock => readerMock.ReadFile(It.IsAny<string>()), Times.Once);
        _jsonSerializerMock.Verify(
            serializerMock => serializerMock.Serialize(It.IsAny<Dictionary<string, WeatherConfigurationModel>>()),
            Times.Once);
        _jsonWriterMock.Verify(
            writerMock => writerMock.WriteFile(It.IsAny<string>(), It.IsAny<string>()),
            Times.Once);
    }
}
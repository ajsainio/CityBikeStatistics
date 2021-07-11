using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorTest.Server.Data;
using BlazorTest.Server.Messages;
using BlazorTest.Shared;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace BlazorTest.Server.MessageHandlers {
  public class SendBikeDataFileHandler : IHandleMessages<SendBikeDataFile> {

    private readonly ILogger<SendBikeDataFileHandler> _logger;

    public SendBikeDataFileHandler(ILogger<SendBikeDataFileHandler> logger) {
      _logger = logger;
    }

    public async Task Handle(SendBikeDataFile message, IMessageHandlerContext context) {
      _logger.LogInformation($"Handling bike data file for year {message.Year} and month {message.Month}");

      await using var fileStream = new MemoryStream(message.FileContent);
      using var reader = new StreamReader(fileStream);

      var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
        Delimiter = ","
      };
      using var csv = new CsvReader(reader, config);

      var map = new CityBikeDataMap(message.Year, message.Month);
      csv.Context.RegisterClassMap(map);

      _logger.LogInformation("Records read, sending messages");
      var records = csv.GetRecords<CityBikeDataContract>();
      foreach (var record in records.Take(10).ToArray()) {
        var recordMessage = new SendBikeDataRecord {
          Record = record
        };
        await context.SendLocal(recordMessage);
        _logger.LogDebug($"Record with record id {recordMessage.Record.RecordId} sent to handling");
      }
    }
  }
}
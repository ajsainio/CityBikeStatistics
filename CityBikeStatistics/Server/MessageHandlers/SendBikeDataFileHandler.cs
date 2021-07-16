using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CityBikeStatistics.Server.Data;
using CityBikeStatistics.Server.Messages;
using CityBikeStatistics.Shared;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace CityBikeStatistics.Server.MessageHandlers {
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

      var records = csv.GetRecords<CityBikeDataContract>().ToArray();


      var handled = 0;
      var total = records.Length;
      const int batchSize = 1000;
      _logger.LogInformation($"{total} records read, sending messages in batch of {batchSize}");

      while (handled < total) {
        
        var batch = records.Skip(handled).Take(batchSize).ToArray();
        var recordMessage = new SendBikeDataRecordBatch {
          Records = batch
        };

        var options = new SendOptions();
        options.RequiredImmediateDispatch();
        options.RouteToThisEndpoint();
        await context.Send(recordMessage, options);
        
        _logger.LogDebug($"Record batch {handled} to {handled + batchSize} sent to handling");

        handled += batchSize;
      }

    }

  }
}
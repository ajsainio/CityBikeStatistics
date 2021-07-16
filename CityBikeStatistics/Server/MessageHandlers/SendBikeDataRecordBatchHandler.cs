using System.Threading.Tasks;
using CityBikeStatistics.Server.Database;
using CityBikeStatistics.Server.Extensions;
using CityBikeStatistics.Server.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace CityBikeStatistics.Server.MessageHandlers {
  public class SendBikeDataRecordBatchHandler : IHandleMessages<SendBikeDataRecordBatch> {
    private readonly CityBikeContext _db;
    private readonly ILogger<SendBikeDataRecordBatchHandler> _logger;

    public SendBikeDataRecordBatchHandler(CityBikeContext db, ILogger<SendBikeDataRecordBatchHandler> logger) {
      _db = db;
      _logger = logger;
    }

    public async Task Handle(SendBikeDataRecordBatch message, IMessageHandlerContext context) {
      foreach (var record in message.Records) {
        _logger.LogInformation($"Handling city bike data record with record id {record.RecordId}");
        var existingRecord = await _db.CityBikeData.SingleOrDefaultAsync(x => x.RecordId == record.RecordId);
        if (existingRecord == null) {
          _logger.LogInformation($"Record {record.RecordId} is new, add to database");
          var newRecord = new CityBikeData(record);
          _db.Add(newRecord);
        } else {
          _logger.LogInformation($"Record {record.RecordId} exists, update");
          existingRecord.CopyFromContract(record);
        }
      }
      await _db.SaveChangesAsync();
    }
  }
}
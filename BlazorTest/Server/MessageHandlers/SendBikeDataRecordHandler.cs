using System.Threading.Tasks;
using BlazorTest.Server.Database;
using BlazorTest.Server.Extensions;
using BlazorTest.Server.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace BlazorTest.Server.MessageHandlers {
  public class SendBikeDataRecordHandler : IHandleMessages<SendBikeDataRecord> {
    private readonly CityBikeContext _db;
    private readonly ILogger<SendBikeDataRecordHandler> _logger;

    public SendBikeDataRecordHandler(CityBikeContext db, ILogger<SendBikeDataRecordHandler> logger) {
      _db = db;
      _logger = logger;
    }

    public async Task Handle(SendBikeDataRecord message, IMessageHandlerContext context) {
      _logger.LogInformation($"Handling city bike data record with record id {message.Record.RecordId}");
      var existingRecord = await _db.CityBikeData.SingleOrDefaultAsync(x => x.RecordId == message.Record.RecordId);
      if (existingRecord == null) {
        _logger.LogInformation($"Record {message.Record.RecordId} is new, add to database");
        var record = new CityBikeData(message.Record);
        _db.Add(record);
      } else {
        _logger.LogInformation($"Record {message.Record.RecordId} exists, update");
        existingRecord.CopyFromContract(message.Record);
      }
      await _db.SaveChangesAsync();
    }
  }
}
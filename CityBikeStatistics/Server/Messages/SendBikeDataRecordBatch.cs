using CityBikeStatistics.Shared;
using NServiceBus;

namespace CityBikeStatistics.Server.Messages {
  public class SendBikeDataRecordBatch : ICommand {
    public CityBikeDataContract[] Records { get; set; }
  }
}
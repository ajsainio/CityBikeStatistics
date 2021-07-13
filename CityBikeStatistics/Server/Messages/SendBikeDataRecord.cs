using CityBikeStatistics.Shared;
using NServiceBus;

namespace CityBikeStatistics.Server.Messages {
  public class SendBikeDataRecord : ICommand {
    public CityBikeDataContract Record { get; set; }
  }
}
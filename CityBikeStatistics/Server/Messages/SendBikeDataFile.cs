using NServiceBus;

namespace CityBikeStatistics.Server.Messages {
  public class SendBikeDataFile : ICommand {
    public int Year { get; set; }
    public int Month { get; set; }
    public byte[] FileContent { get; set; }
  }
}
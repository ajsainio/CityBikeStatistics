using BlazorTest.Shared;
using NServiceBus;

namespace BlazorTest.Server.Messages {
  public class SendBikeDataRecord : ICommand {
    public CityBikeDataContract Record { get; set; }
  }
}
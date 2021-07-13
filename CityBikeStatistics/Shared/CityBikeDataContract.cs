using System;

namespace CityBikeStatistics.Shared {
  public class CityBikeDataContract {
    public int RecordId { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Return { get; set; }
    public int DepartureStationId { get; set; }
    public string DepartureStationName { get; set; }
    public int? ReturnStationId { get; set; }
    public string ReturnStationName { get; set; }
    public decimal CoveredDistance { get; set; }
    public int Duration { get; set; }
  }
}
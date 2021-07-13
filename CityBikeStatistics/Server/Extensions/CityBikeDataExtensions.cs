using CityBikeStatistics.Server.Database;
using CityBikeStatistics.Shared;

namespace CityBikeStatistics.Server.Extensions {
  public static class CityBikeDataExtensions {
    public static void CopyFromContract(this CityBikeData existing, CityBikeDataContract contract) {
      existing.Departure = contract.Departure;
      existing.DepartureStationId = contract.DepartureStationId;
      existing.DepartureStationName = contract.DepartureStationName;
      existing.Return = contract.Return;
      existing.ReturnStationId = contract.ReturnStationId;
      existing.ReturnStationName = contract.ReturnStationName;
      existing.CoveredDistance = contract.CoveredDistance;
      existing.Duration = contract.Duration;
    }
  }
}
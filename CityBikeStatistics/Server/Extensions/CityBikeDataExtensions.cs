using System.Linq;
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

    public static string GetStationNameById(this CityBikeData[] bikeData, int stationId) {
      var station = bikeData.FirstOrDefault(x => x.DepartureStationId == stationId);
      if (station != null) return station.DepartureStationName;
      station = bikeData.FirstOrDefault(x => x.ReturnStationId == stationId);
      return station?.ReturnStationName;
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBikeStatistics.Server.Database;
using CityBikeStatistics.Server.Extensions;
using CityBikeStatistics.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CityBikeStatistics.Server.Data {
  public class CityBikeDataRepository {

    private readonly CityBikeContext _db;
    private readonly ILogger<CityBikeDataRepository> _logger;

    public CityBikeDataRepository(CityBikeContext db, ILogger<CityBikeDataRepository> logger) {
      _db = db;
      _logger = logger;
    }

    public async Task<IEnumerable<CityBikeDataContract>> GetBikeDataByStationId(int stationId, DateTime startTime, DateTime endTime) {
      var records = await GetFilteredData(startTime, endTime);
      return records.Where(x => x.DepartureStationId == stationId || x.ReturnStationId == stationId).OrderBy(x => x.Departure);
    }

    public async Task<IEnumerable<CityBikeStationOverview>> GetStationOverview(DateTime startTime, DateTime endTime) {
      var bikeData = await GetFilteredData(startTime, endTime);
      var stations = GetStations(bikeData);
      var stationData = stations.Select(station =>
        new CityBikeStationOverview {
          StationId = station,
          StationName = bikeData.GetStationNameById(station),
          Departures = bikeData.Count(x => x.DepartureStationId == station),
          Returns = bikeData.Count(x => x.ReturnStationId == station)
        }).ToList();
      return stationData.OrderBy(x => x.StationName);
    }

    private async Task<CityBikeData[]> GetFilteredData(DateTime startTime, DateTime endTime) {
      return await _db.CityBikeData.Where(x => x.Departure >= startTime && x.Departure < endTime).ToArrayAsync();
    }

    private int[] GetStations(CityBikeData[] records) {
      return records.Select(x => x.DepartureStationId).Distinct()
        .Union(records.Where(x => x.ReturnStationId != null).Select(x => x.ReturnStationId).Cast<int>().Distinct())
        .ToArray();
    }

  }
}

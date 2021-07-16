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

    public async Task<IEnumerable<int>> GetStations() {
      return await _db.CityBikeData.Select(x => x.DepartureStationId).Distinct()
        .Union(_db.CityBikeData.Where(x => x.ReturnStationId !=null).Select(x => x.ReturnStationId).Cast<int>().Distinct())
        .ToArrayAsync();
    }

    public async Task<IEnumerable<CityBikeDataContract>> GetBikeDataByStationId(int stationId) {
      return await _db.CityBikeData.Where(x => x.DepartureStationId == stationId || x.ReturnStationId == stationId).OrderBy(x => x.Departure).ToArrayAsync();
    }

    public async Task<IEnumerable<CityBikeStationOverview>> GetStationOverview() {
      var stations = await GetStations();
      var bikeData = await _db.CityBikeData.ToArrayAsync();
      var stationData = stations.Select(station =>
        new CityBikeStationOverview {
          StationId = station,
          StationName = bikeData.GetStationNameById(station),
          Departures = bikeData.Count(x => x.DepartureStationId == station),
          Returns = bikeData.Count(x => x.ReturnStationId == station)
        }).ToList();
      return stationData.OrderBy(x => x.StationName);
    }

  }

}

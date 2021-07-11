using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTest.Server.Database;
using BlazorTest.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorTest.Server.Data {
  public class CityBikeDataRepository {

    private readonly CityBikeContext _db;
    private readonly ILogger<CityBikeDataRepository> _logger;

    public CityBikeDataRepository(CityBikeContext db, ILogger<CityBikeDataRepository> logger) {
      _db = db;
      _logger = logger;
    }

    public async Task<IEnumerable<CityBikeDataContract>> GetCityBikeData() {
      return await _db.CityBikeData.ToArrayAsync();
    }
  }
}
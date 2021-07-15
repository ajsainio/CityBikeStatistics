using System.Collections.Generic;
using System.Threading.Tasks;
using CityBikeStatistics.Server.Data;
using CityBikeStatistics.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityBikeStatistics.Server.Controllers {

  [ApiController]
  [Route("[controller]")]
  public class CityBikeDataController : ControllerBase {

    private readonly CityBikeDataRepository _repository;
    private readonly ILogger<CityBikeDataController> _logger;

    public CityBikeDataController(CityBikeDataRepository repository, ILogger<CityBikeDataController> logger) {
      _repository = repository;
      _logger = logger;
    }

    [HttpGet]
    [Route("Overview")]
    public async Task<IEnumerable<CityBikeStationOverview>> GetBikeDataOverview() {
      _logger.LogInformation("Getting station overview");
      return await _repository.GetStationOverview();
    }

    [HttpGet]
    [Route("Stations")]
    public async Task<IEnumerable<int>> GetBikeStations() {
      _logger.LogInformation("Getting bike stations");
      return await _repository.GetStations();
    }

    [HttpGet]
    [Route("DataByStation/{stationId}")]
    public async Task<IEnumerable<CityBikeDataContract>> GetDataByStation(int stationId) {
      _logger.LogInformation($"Getting data for station {stationId}");
      return await _repository.GetBikeDataByStationId(stationId);
    }
  }
}
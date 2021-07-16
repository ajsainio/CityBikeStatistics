using System;
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
    [Route("Overview/{startTime:datetime}/{endTime:datetime}")]
    public async Task<IEnumerable<CityBikeStationOverview>> GetBikeDataOverview(DateTime startTime, DateTime endTime) {
      _logger.LogInformation($"Getting station overview for time range {startTime:d} - {endTime:d}");
      return await _repository.GetStationOverview(startTime, endTime);
    }

    [HttpGet]
    [Route("DataByStation/{stationId:int}/{startTime:datetime}/{endTime:datetime}")]
    public async Task<IEnumerable<CityBikeDataContract>> GetDataByStation(int stationId, DateTime startTime, DateTime endTime) {
      _logger.LogInformation($"Getting data for station {stationId} with time range {startTime:d} - {endTime:d}");
      return await _repository.GetBikeDataByStationId(stationId, startTime, endTime);
    }
  }
}
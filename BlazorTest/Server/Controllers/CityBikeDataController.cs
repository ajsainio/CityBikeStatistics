using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTest.Server.Data;
using BlazorTest.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorTest.Server.Controllers {

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
    public async Task<IEnumerable<CityBikeDataContract>> GetBikeData() {
      _logger.LogInformation("Getting bikes data");
      return await _repository.GetCityBikeData();

    }
  }
}
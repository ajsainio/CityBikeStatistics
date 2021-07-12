using System;
using System.Threading.Tasks;
using BlazorTest.Server.Services;
using BlazorTest.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorTest.Server.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class CityBikeDataDownloadController : ControllerBase {

    private readonly CityBikeDataService _bikeDataService;
    private readonly ILogger<CityBikeDataDownloadController> _logger;

    public CityBikeDataDownloadController(CityBikeDataService bikeDataService, ILogger<CityBikeDataDownloadController> logger) {
      _bikeDataService = bikeDataService;
      _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCityBikeData(BikeDataDownloadContract contract) {
      try {
        await _bikeDataService.DownloadCityBikeData(contract);
        return Ok();
      } catch (Exception e) {
        _logger.LogError("Error while downloading city bike data", e);
        return new NotFoundResult();
      }

    }
  }
}



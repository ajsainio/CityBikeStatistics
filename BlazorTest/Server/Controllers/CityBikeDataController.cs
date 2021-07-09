using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using BlazorTest.Shared;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorTest.Server.Controllers {

  [ApiController]
  [Route("[controller]")]
  public class CityBikeDataController : ControllerBase {

    private readonly ILogger<CityBikeDataController> _logger;

    public CityBikeDataController(ILogger<CityBikeDataController> logger) {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<CityBikeData> GetBikeData() {
      _logger.LogInformation("Getting bikes data");

      var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
        PrepareHeaderForMatch = x => x.Header.Replace(" ", string.Empty).Replace("(m)", string.Empty).Replace("(sec.)", string.Empty),
        Delimiter = ","
      };
      using var reader = new StreamReader("Data\\2020-10.csv");
      using var csv = new CsvReader(reader, config);
      var records = csv.GetRecords<CityBikeData>();
      return records.Take(10).ToArray();

    }
  }
}
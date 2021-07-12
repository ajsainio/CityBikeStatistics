using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorTest.Server.Messages;
using BlazorTest.Shared;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace BlazorTest.Server.Services {
  public class CityBikeDataService {
    private readonly HttpClient _httpClient;
    private readonly IMessageSession _messageSession;
    private readonly ILogger<CityBikeDataService> _logger;

    public CityBikeDataService(HttpClient httpClient, ILogger<CityBikeDataService> logger, IMessageSession messageSession) {
      _httpClient = httpClient;
      _messageSession = messageSession;
      _logger = logger;
    }

    /// <summary>
    /// Downloads city bike data from hsl
    /// </summary>
    /// <param name="contract">Contract for downloading desired data</param>
    /// <returns>boolean indicating if file was found and downloaded</returns>
    public async Task DownloadCityBikeData(BikeDataDownloadContract contract) {
      _logger.LogInformation($"Get city bike data file for year {contract.Year} and month {contract.Month}");
      var response = await _httpClient.GetAsync($"citybikes/od-trips-{contract.Year}/{contract.Year}-{contract.Month}.csv");

      if (!response.IsSuccessStatusCode) {
        throw new InvalidOperationException($"Downloading file for year {contract.Year} and month {contract.Month} failed");
      }

      var file = await response.Content.ReadAsByteArrayAsync();

      _logger.LogInformation("File downloaded, send to handler");
      var message = new SendBikeDataFile {
        Year = contract.Year,
        Month = contract.Month,
        FileContent = file
      };

      await _messageSession.SendLocal(message);
    }

  }
}
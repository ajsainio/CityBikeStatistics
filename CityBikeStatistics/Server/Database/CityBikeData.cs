using CityBikeStatistics.Server.Extensions;
using CityBikeStatistics.Shared;

namespace CityBikeStatistics.Server.Database {
  public class CityBikeData : CityBikeDataContract {
    public int Id { get; set; }

    public CityBikeData() { }

    public CityBikeData(CityBikeDataContract contract) {
      this.CopyFromContract(contract);
      RecordId = contract.RecordId;
    }
  }
}
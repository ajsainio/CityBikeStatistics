using BlazorTest.Server.Extensions;
using BlazorTest.Shared;

namespace BlazorTest.Server.Database {
  public class CityBikeData : CityBikeDataContract {
    public int Id { get; set; }

    public CityBikeData() { }

    public CityBikeData(CityBikeDataContract contract) {
      this.CopyFromContract(contract);
      RecordId = contract.RecordId;
    }
  }
}
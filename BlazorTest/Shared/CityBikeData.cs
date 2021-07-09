using System;

namespace BlazorTest.Shared {
  public class CityBikeData {
    public DateTime Departure { get; set; }
    public DateTime Return { get; set; }
    public int Departurestationid { get; set; }
    public string Departurestationname { get; set; }
    public int? Returnstationid { get; set; }
    public string Returnstationname { get; set; }
    public decimal Covereddistance { get; set; }
    public int Duration { get; set; }
  }
}
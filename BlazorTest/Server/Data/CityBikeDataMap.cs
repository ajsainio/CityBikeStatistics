﻿using System.Data;
using BlazorTest.Shared;
using CsvHelper.Configuration;

namespace BlazorTest.Server.Data {
  public sealed class CityBikeDataMap : ClassMap<CityBikeDataContract> {
    public CityBikeDataMap(int year, int month) {
      Map(m => m.RecordId).Convert(record => int.Parse("" + year + month + record.Row.Parser.Row));
      Map(m => m.Departure);
      Map(m => m.Return);
      Map(m => m.DepartureStationId).Name("Departure station id");
      Map(m => m.ReturnStationId).Name("Return station id");
      Map(m => m.DepartureStationName).Name("Departure station name");
      Map(m => m.ReturnStationName).Name("Return station name");
      Map(m => m.CoveredDistance).Name("Covered distance (m)");
      Map(m => m.Duration).Name("Duration (sec.)");
    }
  }
}
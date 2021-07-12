using System.ComponentModel.DataAnnotations;

namespace BlazorTest.Shared {
  public class BikeDataDownloadContract {
    [Required]
    [Range(2016,2021, ErrorMessage = "Year must be between 2016 and 2021")]
    public int Year { get; set; }
    [Required]
    [Range(1,12, ErrorMessage = "Month must be between 1 and 12")]
    public int Month { get; set; }

  }
}
using Microsoft.EntityFrameworkCore;

namespace CityBikeStatistics.Server.Database {
  public class CityBikeContext : DbContext {
    public CityBikeContext(DbContextOptions options) : base(options) { }

    public DbSet<CityBikeData> CityBikeData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<CityBikeData>(x => {
        x.HasIndex(i => i.RecordId).IsUnique();
        x.HasIndex(i => i.DepartureStationId);
        x.HasIndex(i => i.ReturnStationId);
        x.HasIndex(i => i.Departure);
        x.Property(p => p.CoveredDistance).HasColumnType("Decimal(18,2)");
      });
    }
  }
}
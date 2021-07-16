﻿// <auto-generated />
using System;
using CityBikeStatistics.Server.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CityBikeStatistics.Server.Migrations
{
    [DbContext(typeof(CityBikeContext))]
    [Migration("20210716120533_DepartureIndex")]
    partial class DepartureIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CityBikeStatistics.Server.Database.CityBikeData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CoveredDistance")
                        .HasColumnType("Decimal(18,2)");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartureStationId")
                        .HasColumnType("int");

                    b.Property<string>("DepartureStationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<long>("RecordId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Return")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReturnStationId")
                        .HasColumnType("int");

                    b.Property<string>("ReturnStationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Departure");

                    b.HasIndex("DepartureStationId");

                    b.HasIndex("RecordId")
                        .IsUnique();

                    b.HasIndex("ReturnStationId");

                    b.ToTable("CityBikeData");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using CoinService.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CoinService.DataLayer.Migrations
{
    [DbContext(typeof(CoinServiceContext))]
    partial class CoinServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CoinService.BusinessLayer.Entities.Tickers.Ticker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Ask");

                    b.Property<decimal>("AskSize");

                    b.Property<decimal>("Bid");

                    b.Property<decimal>("BidSize");

                    b.Property<decimal>("DailyChange");

                    b.Property<decimal>("DailyChangePerc");

                    b.Property<decimal>("High");

                    b.Property<decimal>("LastPrice");

                    b.Property<decimal>("Low");

                    b.Property<string>("Symbol");

                    b.Property<DateTime>("Timestamp");

                    b.Property<decimal>("Volume");

                    b.HasKey("ID");

                    b.ToTable("Tickers");
                });
#pragma warning restore 612, 618
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CoinService.DataLayer.Migrations
{
    public partial class Initializethedatabaseandaddtickers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Symbol = table.Column<string>(nullable: true),
                    Bid = table.Column<float>(nullable: false),
                    BidSize = table.Column<float>(nullable: false),
                    Ask = table.Column<float>(nullable: false),
                    AskSize = table.Column<float>(nullable: false),
                    DailyChange = table.Column<float>(nullable: false),
                    DailyChangePerc = table.Column<float>(nullable: false),
                    LastPrice = table.Column<float>(nullable: false),
                    Volume = table.Column<float>(nullable: false),
                    High = table.Column<float>(nullable: false),
                    Low = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickers");
        }
    }
}

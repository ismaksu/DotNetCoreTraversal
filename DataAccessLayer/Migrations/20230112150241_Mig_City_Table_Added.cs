using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig_City_Table_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Destinations",
                newName: "CityName");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Destinations",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_CityID",
                table: "Destinations",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Cities_CityID",
                table: "Destinations",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Cities_CityID",
                table: "Destinations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_CityID",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Destinations");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Destinations",
                newName: "City");
        }
    }
}

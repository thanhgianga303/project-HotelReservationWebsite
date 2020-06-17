using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationWebsiteAPI.Migrations
{
    public partial class InitialsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HotelName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    HotelStatus = table.Column<int>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    NumberofReservation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HotelID = table.Column<int>(nullable: false),
                    RoomCategoryName = table.Column<string>(nullable: true),
                    RoomNumber = table.Column<int>(nullable: false),
                    RoomName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    RoomStatus = table.Column<int>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    RoomArea = table.Column<string>(nullable: true),
                    NumberOfBeds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelID",
                table: "Rooms",
                column: "HotelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FLAMOM_SeniorProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MouthPain = table.Column<bool>(type: "bit", nullable: false),
                    LengthOfPain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverallHealth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeToTravel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendBefore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeardAbouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitInfoId = table.Column<int>(type: "int", nullable: false),
                    HeardAboutHow = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeardAbouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeardAbouts_VisitInformations_VisitInfoId",
                        column: x => x.VisitInfoId,
                        principalTable: "VisitInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReasonsForVisit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitInfoId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonsForVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonsForVisit_VisitInformations_VisitInfoId",
                        column: x => x.VisitInfoId,
                        principalTable: "VisitInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeardAbouts_VisitInfoId",
                table: "HeardAbouts",
                column: "VisitInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonsForVisit_VisitInfoId",
                table: "ReasonsForVisit",
                column: "VisitInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeardAbouts");

            migrationBuilder.DropTable(
                name: "ReasonsForVisit");

            migrationBuilder.DropTable(
                name: "VisitInformations");
        }
    }
}

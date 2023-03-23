using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FLAMOM_SeniorProject.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MouthPain = table.Column<bool>(type: "bit", nullable: false),
                    LengthOfPain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallHealth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeToTravel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendBefore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeethGums = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainRsn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastVisit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainRsnLstVst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsualCare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emrgncy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastSixMnths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoToOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsualJobs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insurance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherAnswer2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelOfSchool = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServedInMil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hispanic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobSituation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeopleAtHome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WicProg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseIncome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DentalOfficesVisited",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DentalOfficesVisited", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DentalOfficesVisited_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeardAbouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    HeardAboutHow = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeardAbouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeardAbouts_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KindOfHealthcare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindOfHealthcare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KindOfHealthcare_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherReasonsForVisit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    OtherReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherReasonsForVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherReasonsForVisit_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientRace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRace_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReasonsForVisit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonsForVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonsForVisit_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tobacco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tobacco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tobacco_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DentalOfficesVisited_PatientId",
                table: "DentalOfficesVisited",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_HeardAbouts_PatientId",
                table: "HeardAbouts",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_KindOfHealthcare_PatientId",
                table: "KindOfHealthcare",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherReasonsForVisit_PatientId",
                table: "OtherReasonsForVisit",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRace_PatientId",
                table: "PatientRace",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonsForVisit_PatientId",
                table: "ReasonsForVisit",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tobacco_PatientId",
                table: "Tobacco",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DentalOfficesVisited");

            migrationBuilder.DropTable(
                name: "HeardAbouts");

            migrationBuilder.DropTable(
                name: "KindOfHealthcare");

            migrationBuilder.DropTable(
                name: "OtherReasonsForVisit");

            migrationBuilder.DropTable(
                name: "PatientRace");

            migrationBuilder.DropTable(
                name: "ReasonsForVisit");

            migrationBuilder.DropTable(
                name: "Tobacco");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}

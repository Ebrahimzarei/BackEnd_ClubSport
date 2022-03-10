using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Table_FieldSports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldId = table.Column<int>(nullable: false),
                    NameField = table.Column<string>(nullable: true),
                    CodeSportField = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_FieldSports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table_Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Memberid = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Natinalcode = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table_MemberSports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(nullable: false),
                    Ncode = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    HallSportRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_MemberSports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table_HallSports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MemberSportRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_HallSports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_HallSports_Table_MemberSports_MemberSportRef",
                        column: x => x.MemberSportRef,
                        principalTable: "Table_MemberSports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Table_ProgramSports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramSportId = table.Column<int>(nullable: true),
                    NameProgram = table.Column<string>(nullable: true),
                    FromDate = table.Column<string>(nullable: true),
                    ToDate = table.Column<string>(nullable: true),
                    DetailsSport = table.Column<string>(nullable: true),
                    DaysOfYear = table.Column<int>(nullable: false),
                    Day = table.Column<string>(nullable: true),
                    AbsenceCost = table.Column<int>(nullable: false),
                    PMemberSportRef = table.Column<int>(nullable: false),
                    FieldSportRef = table.Column<int>(nullable: false),
                    HallSportRef = table.Column<int>(nullable: false),
                    EventSportRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_ProgramSports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_ProgramSports_Table_FieldSports_FieldSportRef",
                        column: x => x.FieldSportRef,
                        principalTable: "Table_FieldSports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Table_ProgramSports_Table_HallSports_HallSportRef",
                        column: x => x.HallSportRef,
                        principalTable: "Table_HallSports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Table_ProgramSports_Table_MemberSports_PMemberSportRef",
                        column: x => x.PMemberSportRef,
                        principalTable: "Table_MemberSports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Table_ServicesSports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(nullable: true),
                    NameService = table.Column<string>(nullable: true),
                    HallSportRef = table.Column<int>(nullable: false),
                    CoachSport = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_ServicesSports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_ServicesSports_Table_HallSports_HallSportRef",
                        column: x => x.HallSportRef,
                        principalTable: "Table_HallSports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Table_EventSports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: true),
                    NameEvent = table.Column<string>(nullable: true),
                    EventResult = table.Column<string>(nullable: true),
                    RefeRee = table.Column<string>(nullable: true),
                    FromDate = table.Column<string>(nullable: true),
                    ToDate = table.Column<string>(nullable: true),
                    HallSportRef = table.Column<int>(nullable: false),
                    FieldSportRef = table.Column<int>(nullable: false),
                    ProgramSportRef = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_EventSports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_EventSports_Table_FieldSports_FieldSportRef",
                        column: x => x.FieldSportRef,
                        principalTable: "Table_FieldSports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Table_EventSports_Table_HallSports_HallSportRef",
                        column: x => x.HallSportRef,
                        principalTable: "Table_HallSports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Table_EventSports_Table_ProgramSports_ProgramSportRef",
                        column: x => x.ProgramSportRef,
                        principalTable: "Table_ProgramSports",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Table_Members",
                columns: new[] { "Id", "FatherName", "FullName", "Memberid", "Natinalcode", "Password", "Photo", "Role", "Token", "UserName" },
                values: new object[] { 1, "Reaz", "EbrahimZarei", 1, "2289567482", "1234567890", null, "Admin", null, "Ebrahim" });

            migrationBuilder.CreateIndex(
                name: "IX_Table_EventSports_FieldSportRef",
                table: "Table_EventSports",
                column: "FieldSportRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_EventSports_HallSportRef",
                table: "Table_EventSports",
                column: "HallSportRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_EventSports_ProgramSportRef",
                table: "Table_EventSports",
                column: "ProgramSportRef",
                unique: true,
                filter: "[ProgramSportRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Table_HallSports_MemberSportRef",
                table: "Table_HallSports",
                column: "MemberSportRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_ProgramSports_FieldSportRef",
                table: "Table_ProgramSports",
                column: "FieldSportRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_ProgramSports_HallSportRef",
                table: "Table_ProgramSports",
                column: "HallSportRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_ProgramSports_PMemberSportRef",
                table: "Table_ProgramSports",
                column: "PMemberSportRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_ServicesSports_HallSportRef",
                table: "Table_ServicesSports",
                column: "HallSportRef",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Table_EventSports");

            migrationBuilder.DropTable(
                name: "Table_Members");

            migrationBuilder.DropTable(
                name: "Table_ServicesSports");

            migrationBuilder.DropTable(
                name: "Table_Users");

            migrationBuilder.DropTable(
                name: "Table_ProgramSports");

            migrationBuilder.DropTable(
                name: "Table_FieldSports");

            migrationBuilder.DropTable(
                name: "Table_HallSports");

            migrationBuilder.DropTable(
                name: "Table_MemberSports");
        }
    }
}

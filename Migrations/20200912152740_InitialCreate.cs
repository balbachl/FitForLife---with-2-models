using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitForLife.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 30, nullable: false),
                    gender = table.Column<string>(nullable: true),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    state = table.Column<string>(maxLength: 2, nullable: true),
                    zip = table.Column<string>(maxLength: 10, nullable: true),
                    email = table.Column<string>(nullable: true),
                    cell = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statDate = table.Column<DateTime>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    weight = table.Column<float>(nullable: false),
                    height = table.Column<float>(nullable: false),
                    MembersID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Statistics_Membership_MembersID",
                        column: x => x.MembersID,
                        principalTable: "Membership",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "ID", "address", "cell", "city", "email", "gender", "name", "state", "zip" },
                values: new object[] { 1, null, null, null, "lbalbach@nmc.edu", "prefer not to disclose", "Lisa Balbach", null, null });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "ID", "address", "cell", "city", "email", "gender", "name", "state", "zip" },
                values: new object[] { 2, null, null, null, null, "prefer not to disclose", "Shaggy Rogers", null, null });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "ID", "address", "cell", "city", "email", "gender", "name", "state", "zip" },
                values: new object[] { 3, null, null, null, null, "prefer not to disclose", "Daphne Blake", null, null });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "ID", "MembersID", "age", "height", "statDate", "weight" },
                values: new object[] { 1, 1, 57, 64f, new DateTime(2020, 9, 12, 11, 27, 40, 146, DateTimeKind.Local).AddTicks(5194), 118f });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "ID", "MembersID", "age", "height", "statDate", "weight" },
                values: new object[] { 2, 2, 29, 70f, new DateTime(2020, 9, 12, 11, 27, 40, 150, DateTimeKind.Local).AddTicks(7828), 150f });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "ID", "MembersID", "age", "height", "statDate", "weight" },
                values: new object[] { 3, 3, 22, 66f, new DateTime(2020, 9, 12, 11, 27, 40, 150, DateTimeKind.Local).AddTicks(7941), 125f });

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_MembersID",
                table: "Statistics",
                column: "MembersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Membership");
        }
    }
}

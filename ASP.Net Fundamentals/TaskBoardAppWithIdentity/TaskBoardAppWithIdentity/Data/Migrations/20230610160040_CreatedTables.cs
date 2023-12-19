using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardAppWithIdentity.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3a291eb5-8f38-4a5e-a42a-6d76773c7afd", 0, "23c96436-ffe0-4241-ba6b-e691f89a3ebe", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEOfe12LiMwNqOikBDoqJRQk9ZO4OBPl0hBwEbwl/DGw2sLPeWTuLx35sPaCeLkq7Tw==", null, false, "191dddc2-218c-4c7b-80ac-d0724ff50c0c", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 22, 19, 0, 39, 788, DateTimeKind.Local).AddTicks(595), "Implement better styling for all public pages", "3a291eb5-8f38-4a5e-a42a-6d76773c7afd", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 1, 10, 19, 0, 39, 788, DateTimeKind.Local).AddTicks(640), "Create Android client app for the TaskBoard RESTful API", "3a291eb5-8f38-4a5e-a42a-6d76773c7afd", "Android Client App" },
                    { 3, 2, new DateTime(2023, 5, 10, 19, 0, 39, 788, DateTimeKind.Local).AddTicks(643), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "3a291eb5-8f38-4a5e-a42a-6d76773c7afd", "Desktop Client App" },
                    { 4, 3, new DateTime(2022, 6, 10, 19, 0, 39, 788, DateTimeKind.Local).AddTicks(646), "Implement [Create Task] page for adding new tasks", "3a291eb5-8f38-4a5e-a42a-6d76773c7afd", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a291eb5-8f38-4a5e-a42a-6d76773c7afd");
        }
    }
}

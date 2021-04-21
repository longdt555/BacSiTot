using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lib.Data.Migrations
{
    public partial class AddMasterData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterData", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MasterData",
                columns: new[] { "Id", "Description", "GroupId", "IsDeleted", "Name", "Value" },
                values: new object[] { new Guid("e4695a9a-a403-4504-97cd-8cb9fc13bcef"), "Bệnh viện", 2, false, "Hospital", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterData");
        }
    }
}

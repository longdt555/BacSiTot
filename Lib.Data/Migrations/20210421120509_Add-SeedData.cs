using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lib.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FacilityClassificationId",
                table: "FacilityType",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "FacilityType",
                columns: new[] { "Id", "Description", "FacilityClassificationId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("479d14e9-68da-4a06-abba-f6b4773389b2"), "Bệnh viện Đa Khoa", "e4695a9a-a403-4504-97cd-8cb9fc13bcef", false, "General Hospital" },
                    { new Guid("46b0cd5a-2e83-464a-9928-6554064cab10"), "Bệnh viện Nhi", "e4695a9a-a403-4504-97cd-8cb9fc13bcef", false, "Children Hospital" },
                    { new Guid("4d17f2bb-6d2e-4762-afa5-740395c6d883"), "Bệnh viện Da Liễu", "e4695a9a-a403-4504-97cd-8cb9fc13bcef", false, "Dermatology Hospital" },
                    { new Guid("b2fa11cd-e77d-4d38-8762-678b70ff369b"), "Bệnh viện Phụ Sản", "e4695a9a-a403-4504-97cd-8cb9fc13bcef", false, "Maternity Hospital" },
                    { new Guid("4df45d9b-53cc-46ea-8bb6-4cc420c5a35d"), "Phòng khám Đa Khoa", "2cd00e51-35a9-4396-9354-03f976c8018c", false, "General Clinic" },
                    { new Guid("6f4d66f9-84fd-4030-9805-ed411798075a"), "Phòng khám Nhi", "2cd00e51-35a9-4396-9354-03f976c8018c", false, "Children Clinic" },
                    { new Guid("2951bfb5-2bfd-44f7-b4b2-20af69ac845a"), "Phòng khám Da Liễu", "2cd00e51-35a9-4396-9354-03f976c8018c", false, "Dermatology Clinic" },
                    { new Guid("f9094245-b8ec-4ed7-9cf7-306929bcc34d"), "Phòng khám Phụ Sản", "2cd00e51-35a9-4396-9354-03f976c8018c", false, "Maternity Clinic" },
                    { new Guid("a6cb5893-fa04-4b87-8d02-6a8eb4d80a45"), "Cở sở dịch vụ Kính thuốc", "a3dd8301-d9cb-4745-968c-e1424e1db0ff", false, "Glass Medicine" }
                });

            migrationBuilder.InsertData(
                table: "MasterData",
                columns: new[] { "Id", "Description", "GroupId", "IsDeleted", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("2cd00e51-35a9-4396-9354-03f976c8018c"), "Phòng khám", 2, false, "Clinic", null },
                    { new Guid("a3dd8301-d9cb-4745-968c-e1424e1db0ff"), "Cơ sở dịch vụ y tế", 2, false, "Medical Service Facility", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "Id",
                keyValue: new Guid("2951bfb5-2bfd-44f7-b4b2-20af69ac845a"));

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "Id",
                keyValue: new Guid("46b0cd5a-2e83-464a-9928-6554064cab10"));

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "Id",
                keyValue: new Guid("479d14e9-68da-4a06-abba-f6b4773389b2"));

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "Id",
                keyValue: new Guid("4d17f2bb-6d2e-4762-afa5-740395c6d883"));

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "Id",
                keyValue: new Guid("4df45d9b-53cc-46ea-8bb6-4cc420c5a35d"));

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "Id",
                keyValue: new Guid("6f4d66f9-84fd-4030-9805-ed411798075a"));

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "Id",
                keyValue: new Guid("a6cb5893-fa04-4b87-8d02-6a8eb4d80a45"));

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "Id",
                keyValue: new Guid("b2fa11cd-e77d-4d38-8762-678b70ff369b"));

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "Id",
                keyValue: new Guid("f9094245-b8ec-4ed7-9cf7-306929bcc34d"));

            migrationBuilder.DeleteData(
                table: "MasterData",
                keyColumn: "Id",
                keyValue: new Guid("2cd00e51-35a9-4396-9354-03f976c8018c"));

            migrationBuilder.DeleteData(
                table: "MasterData",
                keyColumn: "Id",
                keyValue: new Guid("a3dd8301-d9cb-4745-968c-e1424e1db0ff"));

            migrationBuilder.AlterColumn<int>(
                name: "FacilityClassificationId",
                table: "FacilityType",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

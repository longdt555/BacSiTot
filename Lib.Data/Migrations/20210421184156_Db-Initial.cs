using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lib.Data.Migrations
{
    public partial class DbInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacilityType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FacilityClassificationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthFacility",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Commune = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    BannerUrl = table.Column<string>(nullable: true),
                    ThumbnailImageUrl = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FanPage = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    WorkingTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthFacility", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "FacilityReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    TimeVisited = table.Column<string>(nullable: true),
                    RecommendUsing = table.Column<bool>(nullable: false),
                    Question1Score = table.Column<float>(nullable: false),
                    Question2Score = table.Column<float>(nullable: false),
                    Question3Score = table.Column<float>(nullable: false),
                    Question4Score = table.Column<float>(nullable: false),
                    HealthFacilityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilityReview_HealthFacility_HealthFacilityId",
                        column: x => x.HealthFacilityId,
                        principalTable: "HealthFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HealthFacilityService",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HealthFacilityId = table.Column<Guid>(nullable: false),
                    DiseasesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthFacilityService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthFacilityService_Diseases_DiseasesId",
                        column: x => x.DiseasesId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthFacilityService_HealthFacility_HealthFacilityId",
                        column: x => x.HealthFacilityId,
                        principalTable: "HealthFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthFacilityType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    HealthFacilityId = table.Column<Guid>(nullable: false),
                    FacilityTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthFacilityType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthFacilityType_FacilityType_FacilityTypeId",
                        column: x => x.FacilityTypeId,
                        principalTable: "FacilityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthFacilityType_HealthFacility_HealthFacilityId",
                        column: x => x.HealthFacilityId,
                        principalTable: "HealthFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diseases",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("853fe502-833d-4027-a8a5-14ffe71901c7"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", false, "Tụy" },
                    { new Guid("d9a2ad86-fa30-4ae4-a657-fe4d70a03100"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", false, "Cột sống" },
                    { new Guid("450e798f-160e-47d0-9de4-8cab976605ef"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", false, "Trĩ" },
                    { new Guid("f6b123b7-4c61-4f53-be12-aa9bf6a6c0f9"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", false, "Tim" },
                    { new Guid("8e424064-c4ea-4d27-ab24-99febc863915"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", false, "Thận" }
                });

            migrationBuilder.InsertData(
                table: "FacilityType",
                columns: new[] { "Id", "Description", "FacilityClassificationId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("a6cb5893-fa04-4b87-8d02-6a8eb4d80a45"), "Cở sở dịch vụ Kính thuốc", "a3dd8301-d9cb-4745-968c-e1424e1db0ff", false, "Glass Medicine" },
                    { new Guid("f9094245-b8ec-4ed7-9cf7-306929bcc34d"), "Phòng khám Phụ Sản", "2cd00e51-35a9-4396-9354-03f976c8018c", false, "Maternity Clinic" },
                    { new Guid("2951bfb5-2bfd-44f7-b4b2-20af69ac845a"), "Phòng khám Da Liễu", "2cd00e51-35a9-4396-9354-03f976c8018c", false, "Dermatology Clinic" },
                    { new Guid("6f4d66f9-84fd-4030-9805-ed411798075a"), "Phòng khám Nhi", "2cd00e51-35a9-4396-9354-03f976c8018c", false, "Children Clinic" },
                    { new Guid("4df45d9b-53cc-46ea-8bb6-4cc420c5a35d"), "Phòng khám Đa Khoa", "2cd00e51-35a9-4396-9354-03f976c8018c", false, "General Clinic" },
                    { new Guid("b2fa11cd-e77d-4d38-8762-678b70ff369b"), "Bệnh viện Phụ Sản", "e4695a9a-a403-4504-97cd-8cb9fc13bcef", false, "Maternity Hospital" },
                    { new Guid("4d17f2bb-6d2e-4762-afa5-740395c6d883"), "Bệnh viện Da Liễu", "e4695a9a-a403-4504-97cd-8cb9fc13bcef", false, "Dermatology Hospital" },
                    { new Guid("46b0cd5a-2e83-464a-9928-6554064cab10"), "Bệnh viện Nhi", "e4695a9a-a403-4504-97cd-8cb9fc13bcef", false, "Children Hospital" },
                    { new Guid("479d14e9-68da-4a06-abba-f6b4773389b2"), "Bệnh viện Đa Khoa", "e4695a9a-a403-4504-97cd-8cb9fc13bcef", false, "General Hospital" }
                });

            migrationBuilder.InsertData(
                table: "HealthFacility",
                columns: new[] { "Id", "Address", "BannerUrl", "Bio", "Commune", "CreatedBy", "CreatedDate", "Description", "District", "FanPage", "IsDeleted", "LogoUrl", "Name", "PhoneNumber", "Province", "ThumbnailImageUrl", "UpdatedBy", "UpdatedDate", "Website", "WorkingTime" },
                values: new object[,]
                {
                    { new Guid("b7f7291c-6c11-4eb3-807a-43eff567df74"), "KĐT Time City", "bannerDetail.png", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.", "458 Minh Khai", null, new DateTime(2021, 4, 22, 1, 41, 55, 866, DateTimeKind.Local).AddTicks(5578), "Bệnh viện hàng đầu việt nam", "Hai Bà Trưng", "Vinmec International Hospital", false, "logoHos.png", "Bệnh viện Đa khoa quốc tế Vinmec", "(024) 36 686868", "Hà Nội", "Frame 548.png", null, null, "https//www.vinmec.com", "8h00 - 20h00" },
                    { new Guid("9ac495b8-8f2a-4977-ad8b-bf47f52d7585"), "KĐT Time City", "bannerDetail.png", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.", "458 Minh Khai", null, new DateTime(2021, 4, 22, 1, 41, 55, 867, DateTimeKind.Local).AddTicks(8594), "Bệnh viện hàng đầu việt nam", "Hai Bà Trưng", "Vinmec International Hospital", false, "logoHos.png", "Phòng khám Đa khoa Hoàng Long", "(024) 36 686868", "Hà Nội", "Frame 548.png", null, null, "https//www.vinmec.com", "8h00 - 20h00" },
                    { new Guid("181049cd-5e5b-4393-adfd-9265b0b28088"), "KĐT Time City", "bannerDetail.png", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.", "458 Minh Khai", null, new DateTime(2021, 4, 22, 1, 41, 55, 867, DateTimeKind.Local).AddTicks(8655), "Bệnh viện hàng đầu việt nam", "Hai Bà Trưng", "Vinmec International Hospital", false, "logoHos.png", "Cơ sở dịch vụ kính thuốc tư nhân Thiên Thanh", "(024) 36 686868", "Hà Nội", "Frame 548.png", null, null, "https//www.vinmec.com", "8h00 - 20h00" }
                });

            migrationBuilder.InsertData(
                table: "MasterData",
                columns: new[] { "Id", "Description", "GroupId", "IsDeleted", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("e4695a9a-a403-4504-97cd-8cb9fc13bcef"), "Bệnh viện", 2, false, "Hospital", null },
                    { new Guid("2cd00e51-35a9-4396-9354-03f976c8018c"), "Phòng khám", 2, false, "Clinic", null },
                    { new Guid("a3dd8301-d9cb-4745-968c-e1424e1db0ff"), "Cơ sở dịch vụ y tế", 2, false, "Medical Service Facility", null }
                });

            migrationBuilder.InsertData(
                table: "HealthFacilityType",
                columns: new[] { "Id", "FacilityTypeId", "HealthFacilityId", "IsDeleted" },
                values: new object[] { new Guid("853fe502-833d-4027-a8a5-14ffe71901c7"), new Guid("479d14e9-68da-4a06-abba-f6b4773389b2"), new Guid("b7f7291c-6c11-4eb3-807a-43eff567df74"), false });

            migrationBuilder.InsertData(
                table: "HealthFacilityType",
                columns: new[] { "Id", "FacilityTypeId", "HealthFacilityId", "IsDeleted" },
                values: new object[] { new Guid("54ab21c7-caf4-4b30-882f-40d7bb42fb0c"), new Guid("4df45d9b-53cc-46ea-8bb6-4cc420c5a35d"), new Guid("9ac495b8-8f2a-4977-ad8b-bf47f52d7585"), false });

            migrationBuilder.InsertData(
                table: "HealthFacilityType",
                columns: new[] { "Id", "FacilityTypeId", "HealthFacilityId", "IsDeleted" },
                values: new object[] { new Guid("b190e392-1333-42c8-a3db-461116d3020f"), new Guid("a6cb5893-fa04-4b87-8d02-6a8eb4d80a45"), new Guid("181049cd-5e5b-4393-adfd-9265b0b28088"), false });

            migrationBuilder.CreateIndex(
                name: "IX_FacilityReview_HealthFacilityId",
                table: "FacilityReview",
                column: "HealthFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthFacilityService_DiseasesId",
                table: "HealthFacilityService",
                column: "DiseasesId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthFacilityService_HealthFacilityId",
                table: "HealthFacilityService",
                column: "HealthFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthFacilityType_FacilityTypeId",
                table: "HealthFacilityType",
                column: "FacilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthFacilityType_HealthFacilityId",
                table: "HealthFacilityType",
                column: "HealthFacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityReview");

            migrationBuilder.DropTable(
                name: "HealthFacilityService");

            migrationBuilder.DropTable(
                name: "HealthFacilityType");

            migrationBuilder.DropTable(
                name: "MasterData");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "FacilityType");

            migrationBuilder.DropTable(
                name: "HealthFacility");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lib.Data.Migrations
{
    public partial class InititalDb : Migration
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
                    FacilityClassificationId = table.Column<int>(nullable: false)
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
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "FacilityType");

            migrationBuilder.DropTable(
                name: "HealthFacility");
        }
    }
}

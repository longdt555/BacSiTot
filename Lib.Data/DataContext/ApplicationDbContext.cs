using System;
using Lib.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lib.Data.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<HealthFacilityModel> HealthFacilities { get; set; }
        public DbSet<FacilityReviewModel> FacilityReviews { get; set; }
        public DbSet<HealthFacilityServiceModel> HealthFacilityServices { get; set; }
        public DbSet<DiseasesModel> Diseases { get; set; }
        public DbSet<FacilityTypeModel> FacilityTypes { get; set; }
        public DbSet<HealthFacilityTypeModel> HealthFacilityTypes { get; set; }
        public DbSet<MasterDataModel> MasterData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region [Master Data]

            //Facility Classification
            modelBuilder.Entity<MasterDataModel>().HasData(
                new MasterDataModel()
                {
                    Id = Guid.Parse("e4695a9a-a403-4504-97cd-8cb9fc13bcef"),
                    Name = "Hospital",
                    Description = "Bệnh viện",
                    GroupId = 2
                },
                new MasterDataModel()
                {
                    Id = Guid.Parse("2cd00e51-35a9-4396-9354-03f976c8018c"),
                    Name = "Clinic",
                    Description = "Phòng khám",
                    GroupId = 2
                },
                new MasterDataModel()
                {
                    Id = Guid.Parse("a3dd8301-d9cb-4745-968c-e1424e1db0ff"),
                    Name = "Medical Service Facility",
                    Description = "Cơ sở dịch vụ y tế",
                    GroupId = 2
                }
            );

            #endregion [Master Data]

            #region [Facility Type]

            modelBuilder.Entity<FacilityTypeModel>().HasData(
                //Hospital
                new FacilityTypeModel()
                {
                    Id = Guid.Parse("479d14e9-68da-4a06-abba-f6b4773389b2"),
                    Name = "General Hospital",
                    Description = "Bệnh viện Đa Khoa",
                    FacilityClassificationId = "e4695a9a-a403-4504-97cd-8cb9fc13bcef"
                },
                new FacilityTypeModel()
                {
                    Id = Guid.Parse("46b0cd5a-2e83-464a-9928-6554064cab10"),
                    Name = "Children Hospital",
                    Description = "Bệnh viện Nhi",
                    FacilityClassificationId = "e4695a9a-a403-4504-97cd-8cb9fc13bcef"
                },
                new FacilityTypeModel()
                {
                    Id = Guid.Parse("4d17f2bb-6d2e-4762-afa5-740395c6d883"),
                    Name = "Dermatology Hospital",
                    Description = "Bệnh viện Da Liễu",
                    FacilityClassificationId = "e4695a9a-a403-4504-97cd-8cb9fc13bcef"
                },
                new FacilityTypeModel()
                {
                    Id = Guid.Parse("b2fa11cd-e77d-4d38-8762-678b70ff369b"),
                    Name = "Maternity Hospital",
                    Description = "Bệnh viện Phụ Sản",
                    FacilityClassificationId = "e4695a9a-a403-4504-97cd-8cb9fc13bcef"
                },

                //Clinic
                new FacilityTypeModel()
                {
                    Id = Guid.Parse("4df45d9b-53cc-46ea-8bb6-4cc420c5a35d"),
                    Name = "General Clinic",
                    Description = "Phòng khám Đa Khoa",
                    FacilityClassificationId = "2cd00e51-35a9-4396-9354-03f976c8018c"
                },
                new FacilityTypeModel()
                {
                    Id = Guid.Parse("6f4d66f9-84fd-4030-9805-ed411798075a"),
                    Name = "Children Clinic",
                    Description = "Phòng khám Nhi",
                    FacilityClassificationId = "2cd00e51-35a9-4396-9354-03f976c8018c"
                },
                new FacilityTypeModel()
                {
                    Id = Guid.Parse("2951bfb5-2bfd-44f7-b4b2-20af69ac845a"),
                    Name = "Dermatology Clinic",
                    Description = "Phòng khám Da Liễu",
                    FacilityClassificationId = "2cd00e51-35a9-4396-9354-03f976c8018c"
                },
                new FacilityTypeModel()
                {
                    Id = Guid.Parse("f9094245-b8ec-4ed7-9cf7-306929bcc34d"),
                    Name = "Maternity Clinic",
                    Description = "Phòng khám Phụ Sản",
                    FacilityClassificationId = "2cd00e51-35a9-4396-9354-03f976c8018c"
                },

                //Medical Service Facility
                new FacilityTypeModel()
                {
                    Id = Guid.Parse("a6cb5893-fa04-4b87-8d02-6a8eb4d80a45"),
                    Name = "Glass Medicine",
                    Description = "Cở sở dịch vụ Kính thuốc",
                    FacilityClassificationId = "a3dd8301-d9cb-4745-968c-e1424e1db0ff"
                }
            );

            #endregion [Facility Type]

            #region [Health Facility]

            modelBuilder.Entity<HealthFacilityModel>().HasData(
                new HealthFacilityModel()
                {
                    Id = Guid.Parse("b7f7291c-6c11-4eb3-807a-43eff567df74"),
                    Name = "Bệnh viện Đa khoa quốc tế Vinmec",
                    Address = "KĐT Time City",
                    Province = "Hà Nội",
                    District = "Hai Bà Trưng",
                    Commune = "458 Minh Khai",
                    LogoUrl = "logoHos.png",
                    BannerUrl = "bannerDetail.png",
                    ThumbnailImageUrl = "Frame 548.png",
                    Website = "https//www.vinmec.com",
                    PhoneNumber = "(024) 36 686868",
                    FanPage = "Vinmec International Hospital",
                    Description = "Bệnh viện hàng đầu việt nam",
                    Bio =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                    WorkingTime = "8h00 - 20h00",
                    CreatedDate = DateTime.Now
                },
                new HealthFacilityModel()
                {
                    Id = Guid.Parse("9ac495b8-8f2a-4977-ad8b-bf47f52d7585"),
                    Name = "Phòng khám Đa khoa Hoàng Long",
                    Address = "KĐT Time City",
                    Province = "Hà Nội",
                    District = "Hai Bà Trưng",
                    Commune = "458 Minh Khai",
                    LogoUrl = "logoHos.png",
                    BannerUrl = "bannerDetail.png",
                    ThumbnailImageUrl = "Frame 548.png",
                    Website = "https//www.vinmec.com",
                    PhoneNumber = "(024) 36 686868",
                    FanPage = "Vinmec International Hospital",
                    Description = "Bệnh viện hàng đầu việt nam",
                    Bio =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                    WorkingTime = "8h00 - 20h00",
                    CreatedDate = DateTime.Now
                },
                new HealthFacilityModel()
                {
                    Id = Guid.Parse("181049cd-5e5b-4393-adfd-9265b0b28088"),
                    Name = "Cơ sở dịch vụ kính thuốc tư nhân Thiên Thanh",
                    Address = "KĐT Time City",
                    Province = "Hà Nội",
                    District = "Hai Bà Trưng",
                    Commune = "458 Minh Khai",
                    LogoUrl = "logoHos.png",
                    BannerUrl = "bannerDetail.png",
                    ThumbnailImageUrl = "Frame 548.png",
                    Website = "https//www.vinmec.com",
                    PhoneNumber = "(024) 36 686868",
                    FanPage = "Vinmec International Hospital",
                    Description = "Bệnh viện hàng đầu việt nam",
                    Bio =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                    WorkingTime = "8h00 - 20h00",
                    CreatedDate = DateTime.Now
                }
            );

            #endregion [Health Facility]

            #region [Health Facility Type Mapping]

            modelBuilder.Entity<HealthFacilityTypeModel>().HasData(
                new HealthFacilityTypeModel()
                {
                    Id = Guid.Parse("853fe502-833d-4027-a8a5-14ffe71901c7"),
                    HealthFacilityId = Guid.Parse("b7f7291c-6c11-4eb3-807a-43eff567df74"),
                    FacilityTypeId = Guid.Parse("479d14e9-68da-4a06-abba-f6b4773389b2")
                },
                new HealthFacilityTypeModel()
                {
                    Id = Guid.Parse("54ab21c7-caf4-4b30-882f-40d7bb42fb0c"),
                    HealthFacilityId = Guid.Parse("9ac495b8-8f2a-4977-ad8b-bf47f52d7585"),
                    FacilityTypeId = Guid.Parse("4df45d9b-53cc-46ea-8bb6-4cc420c5a35d")
                },
                new HealthFacilityTypeModel()
                {
                    Id = Guid.Parse("b190e392-1333-42c8-a3db-461116d3020f"),
                    HealthFacilityId = Guid.Parse("181049cd-5e5b-4393-adfd-9265b0b28088"),
                    FacilityTypeId = Guid.Parse("a6cb5893-fa04-4b87-8d02-6a8eb4d80a45")
                }
            );

            #endregion [Health Facility Type Mapping]

            #region [Diseases]

            modelBuilder.Entity<DiseasesModel>().HasData(
                new DiseasesModel()
                {
                    Id = Guid.Parse("853fe502-833d-4027-a8a5-14ffe71901c7"),
                    Name = "Tụy",
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                new DiseasesModel()
                {
                    Id = Guid.Parse("d9a2ad86-fa30-4ae4-a657-fe4d70a03100"),
                    Name = "Cột sống",
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                new DiseasesModel()
                {
                    Id = Guid.Parse("450e798f-160e-47d0-9de4-8cab976605ef"),
                    Name = "Trĩ",
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                new DiseasesModel()
                {
                    Id = Guid.Parse("f6b123b7-4c61-4f53-be12-aa9bf6a6c0f9"),
                    Name = "Tim",
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                new DiseasesModel()
                {
                    Id = Guid.Parse("8e424064-c4ea-4d27-ab24-99febc863915"),
                    Name = "Thận",
                    Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                }
            );

            #endregion [Diseases]
        }
    }
}
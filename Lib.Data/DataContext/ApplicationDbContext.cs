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

            #region [Facility Classification]

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

            #endregion [Facility Classification]

            #endregion [Master Data]

            #region [Facility Type]

            modelBuilder.Entity<FacilityTypeModel>().HasData(

            #region [Hospital]

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

            #endregion [Hospital]

            #region [Clinic]

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

            #endregion [Clinic]

            #region [Medical Service Facility]

                new FacilityTypeModel()
                {
                    Id = Guid.Parse("a6cb5893-fa04-4b87-8d02-6a8eb4d80a45"),
                    Name = "Glass Medicine",
                    Description = "Cở sở dịch vụ Kính thuốc",
                    FacilityClassificationId = "a3dd8301-d9cb-4745-968c-e1424e1db0ff"
                }

                #endregion [Medical Service Facility]

            );

            #endregion [Facility Type]

            #region [Health Facility]


            #endregion [Health Facility]
        }
    }
}
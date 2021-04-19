using Lib.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lib.Data.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<HealthFacilityModel> HealthFacilities { get; set; }
        public DbSet<FacilityReviewModel> FacilityReviews { get; set; }
        public DbSet<HealthFacilityServiceModel> HealthFacilityServices { get; set; }
        public DbSet<DiseasesModel> Diseases { get; set; }
        public DbSet<FacilityTypeModel> FacilityTypes { get; set; }
        public DbSet<HealthFacilityTypeModel> HealthFacilityTypes { get; set; }
    }
}
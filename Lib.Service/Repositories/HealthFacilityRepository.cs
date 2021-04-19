using System;
using System.Collections.Generic;
using Lib.Repository.Repositories.IRepository;

namespace Lib.Repository.Repositories
{
    public class HealthFacilityRepository : Repository<HealthFacilityModel>, IHealthFacilityRepository
    {
        private readonly ApplicationDbContext _db;

        public HealthFacilityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public HealthFacilityViewModel GetById(Guid id)
        {
            var data = _db.HealthFacilities
                .Include(x => x.FacilityReviews)
                .Include(x =>x.HealthFacilityTypes).ThenInclude(x =>x.FacilityType)
                .FirstOrDefault(x => x.Id.Equals(id));

            return data != null
                ? new HealthFacilityViewModel()
                {
                    FacilityType = data.HealthFacilityTypes.FirstOrDefault()?.FacilityType,
                    HealthFacility = data,
                    TotalReviews = data.FacilityReviews.Count(),
                    AverageRating = !data.FacilityReviews.Any()
                        ? 0
                        : Math.Round(data.FacilityReviews.Sum(x => x.AveragePoint) / data.FacilityReviews.Count(), 1),
                    OneStar = !data.FacilityReviews.Any()
                        ? 0
                        : data.FacilityReviews.Count(x => Math.Round(x.AveragePoint) == 1),
                    TwoStars = !data.FacilityReviews.Any()
                        ? 0
                        : data.FacilityReviews.Count(x => Math.Round(x.AveragePoint) == 2),
                    ThreeStars = !data.FacilityReviews.Any()
                        ? 0
                        : data.FacilityReviews.Count(x => Math.Round(x.AveragePoint) == 3),
                    FourStars = !data.FacilityReviews.Any()
                        ? 0
                        : data.FacilityReviews.Count(x => Math.Round(x.AveragePoint) == 4),
                    FiveStars = !data.FacilityReviews.Any()
                        ? 0
                        : data.FacilityReviews.Count(x => Math.Round(x.AveragePoint) == 5),
                }
                : null;
        }

        public IEnumerable<HealthFacilityViewModel> GetTopHealthFacilityByAverageRating(int take, Guid healthFacilityType)
        {

            var data = _db.HealthFacilities
                .Include(x => x.HealthFacilityTypes).ThenInclude(x => x.FacilityType)
                .Include(x => x.FacilityReviews)
                .Where(x => x.HealthFacilityTypes.Any(y => y.FacilityType.Id == healthFacilityType))
                .Select(x => new HealthFacilityViewModel()
                {
                    HealthFacility = x,
                    AverageRating = x.FacilityReviews.Select(y => (y.Question1Score + y.Question2Score + y.Question3Score + y.Question4Score) / 4).Sum() / x.FacilityReviews.Count()
                }).OrderByDescending(x => x.AverageRating).Take(take);
            return data;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Repository.Dto;
using Lib.Repository.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lib.Repository.Repositories
{
    public class HealthFacilityRepository : Repository<HealthFacilityModel>, IHealthFacilityRepository
    {
        private readonly ApplicationDbContext _db;

        public HealthFacilityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Get health facility by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HealthFacilityDto</returns>
        public HealthFacilityDto GetById(Guid id)
        {
            var data = _db.HealthFacilities
                .Include(x => x.FacilityReviews)
                .Include(x => x.HealthFacilityTypes).ThenInclude(x => x.FacilityType)
                .FirstOrDefault(x => x.Id.Equals(id));

            return data != null
                ? new HealthFacilityDto
                {
                    FacilityType = data.HealthFacilityTypes.FirstOrDefault()?.FacilityType != null ? new FacilityTypeModel()
                    {
                        Id = data.HealthFacilityTypes.FirstOrDefault().FacilityType.Id,
                        Name = data.HealthFacilityTypes.FirstOrDefault()?.FacilityType.Name,
                        Description = data.HealthFacilityTypes.FirstOrDefault()?.FacilityType.Description,
                        FacilityClassificationId = data.HealthFacilityTypes.FirstOrDefault()?.FacilityType.FacilityClassificationId
                    } : null,
                    HealthFacility = new HealthFacilityModel()
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Address = data.Address,
                        District = data.District,
                        Province = data.Province,
                        Commune = data.Commune,
                        BannerUrl = data.Address,
                        Bio = data.Bio,
                        Description = data.Description,
                        FanPage = data.FanPage,
                        CreatedBy = data.CreatedBy,
                        CreatedDate = data.CreatedDate,
                        PhoneNumber = data.PhoneNumber,
                        LogoUrl = data.LogoUrl,
                        ThumbnailImageUrl = data.ThumbnailImageUrl,
                        IsDeleted = data.IsDeleted,
                        UpdatedBy = data.UpdatedBy,
                        UpdatedDate = data.UpdatedDate,
                        Website = data.Website,
                        WorkingTime = data.WorkingTime
                    },
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

        /// <summary>
        /// get top of health facility order by descending average rating
        /// </summary>
        /// <param name="take"></param>
        /// <param name="healthFacilityType"></param>
        /// <returns>HealthFacilityDto</returns>
        public IEnumerable<HealthFacilityDto> GetTopHealthFacility(int take, Guid healthFacilityType)
        {
            var data = _db.HealthFacilities
                .Include(x => x.HealthFacilityTypes).ThenInclude(x => x.FacilityType)
                .Include(x => x.FacilityReviews)
                .Where(x => x.HealthFacilityTypes.Any(y => y.FacilityType.Id == healthFacilityType))
                .Select(x => new HealthFacilityDto()
                {
                    HealthFacility = x,
                    FacilityType = x.HealthFacilityTypes.FirstOrDefault().FacilityType,
                    AverageRating =
                        x.FacilityReviews.Select(y =>
                            (y.Question1Score + y.Question2Score + y.Question3Score + y.Question4Score) / 4).Sum() /
                        x.FacilityReviews.Count()
                }).OrderByDescending(x => x.AverageRating).Take(take);
            return data;
        }
    }
}
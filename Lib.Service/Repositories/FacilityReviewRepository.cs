﻿using System;
using System.Linq;
using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Repository.Dto.Parameters;
using Lib.Repository.Dto.Results;
using Lib.Repository.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lib.Repository.Repositories
{
    public class FacilityReviewRepository : Repository<FacilityReviewModel>, IFacilityReviewRepository
    {
        private readonly ApplicationDbContext _db;

        public FacilityReviewRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public ModelSearchResult<FacilityReviewModel> GetAllByHealthFacilityId(
            ModelSearchParameter<FacilityReviewParam> objParam)
        {
            var data = _db.FacilityReviews.Include(x => x.HealthFacility).Where(x =>
                    x.IsDeleted == false && x.HealthFacility.Id.Equals(objParam.Filter.HealthFacilityId))
                .OrderByDescending(x => x.UpdatedDate ?? x.CreatedDate);

            var dataPagination = data.Skip((objParam.PageNumber - 1) * objParam.PageSize).Take(objParam.PageSize);

            return new ModelSearchResult<FacilityReviewModel>
            {
                Data = dataPagination,
                TotalCount = data.Count(),
                CurrentPage = objParam.PageNumber
            };
        }

        public void Save(FacilityReviewModel model, string healthFacilityId)
        {
            var healthFacility =
                _db.HealthFacilities.FirstOrDefault(x => x.Id.ToString().ToLower().Equals(healthFacilityId.ToLower()));
            if (healthFacility == null)
                throw new AppException(AppStatusMessage.ObjectNotFound);
            model.HealthFacility = healthFacility;
            model.CreatedDate = DateTime.Now;
            model.UpdatedDate = DateTime.Now;
            _db.FacilityReviews.Add(model);
            _db.SaveChanges();
        }
    }
}
using System;
using Lib.Repository.Repositories.IRepository;

namespace Lib.Repository.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Lock User
        /// </summary>
        /// <param name="id"></param>
        public void LockUser(string id)
        {
            var entity = _db.ApplicationUser.FirstOrDefault(u => u.Id.Equals(id));
            entity.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        /// <summary>
        /// Unlock User
        /// </summary>
        /// <param name="id"></param>
        public void UnlockUser(string id)
        {
            var entity = _db.ApplicationUser.FirstOrDefault(u => u.Id.Equals(id));
            entity.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}

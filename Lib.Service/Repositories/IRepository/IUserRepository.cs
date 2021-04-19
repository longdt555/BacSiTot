namespace Lib.Repository.Repositories.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        /// <summary>
        /// Lock User
        /// </summary>
        /// <param name="id"></param>
        void LockUser(string id);

        /// <summary>
        /// Unlock User
        /// </summary>
        /// <param name="id"></param>
        void UnlockUser(string id);
    }
}

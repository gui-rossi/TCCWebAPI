using TCCDomain.Entities;

namespace TCCRepositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        Task<UserEntity> FindByEmailAsync(string email);
    }
}

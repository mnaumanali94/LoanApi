namespace LoanApi.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using LoanApi.Models;

    public interface IUserRepository
    {
        Task<User> AddAsync(User user, CancellationToken cancellationToken);

        Task DeleteAsync(User user, CancellationToken cancellationToken);

        Task<User> GetAsync(int userId, CancellationToken cancellationToken);

        Task<List<User>> GetUsersAsync(
            CancellationToken cancellationToken);

        Task<User> UpdateAsync(User user, CancellationToken cancellationToken);
    }
}

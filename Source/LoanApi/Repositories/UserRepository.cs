namespace LoanApi.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using LoanApi.Models;

    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users = new List<User>()
        {
            new User()
            {
                UserId = 1,
                IncorporationDate = DateTime.UtcNow.AddDays(-8),
                LoanPurpose = "I need to get rich",
                Industry = "Finance",
                Revenue = 100000,
                RequestedAmount = 5000
            },
            new User()
            {
                UserId = 2,
                IncorporationDate = DateTime.UtcNow.AddDays(-7),
                LoanPurpose = "I need to get richer",
                Industry = "Automaker",
                Revenue = 200000,
                RequestedAmount = 15000
            },
            new User()
            {
                UserId = 3,
                IncorporationDate = DateTime.UtcNow.AddDays(-17),
                LoanPurpose = "I need to get the richest",
                Industry = "Information Technology",
                Revenue = 2900000,
                RequestedAmount = 150900
            },
        };

        public Task<User> AddAsync(User user, CancellationToken cancellationToken)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            Users.Add(user);
            user.UserId = Users.Max(x => x.UserId) + 1;
            return Task.FromResult(user);
        }

        public Task DeleteAsync(User user, CancellationToken cancellationToken)
        {
            if (Users.Contains(user))
            {
                Users.Remove(user);
            }

            return Task.CompletedTask;
        }

        public Task<User> GetAsync(int userId, CancellationToken cancellationToken)
        {
            var user = Users.FirstOrDefault(x => x.UserId == userId);
            return Task.FromResult(user);
        }

        public Task<List<User>> GetUsersAsync(
            CancellationToken cancellationToken) =>
            Task.FromResult(Users
                .ToList());

        public Task<User> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var existingUser = Users.FirstOrDefault(x => x.UserId == user.UserId);
            existingUser.IncorporationDate = user.IncorporationDate;
            existingUser.LoanPurpose = user.LoanPurpose;
            existingUser.Industry = user.Industry;
            existingUser.RequestedAmount = user.RequestedAmount;
            existingUser.Revenue = user.Revenue;
            return Task.FromResult(user);
        }
    }
}

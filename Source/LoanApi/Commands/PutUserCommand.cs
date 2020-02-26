namespace LoanApi.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using LoanApi.Repositories;
    using LoanApi.ViewModels;
    using Boxed.Mapping;
    using Microsoft.AspNetCore.Mvc;

    public class PutUserCommand : IPutUserCommand
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper<Models.User, User> userToUserMapper;
        private readonly IMapper<SaveUser, Models.User> saveUserToUserMapper;

        public PutUserCommand(
            IUserRepository userRepository,
            IMapper<Models.User, User> userToUserMapper,
            IMapper<SaveUser, Models.User> saveUserToUserMapper)
        {
            this.userRepository = userRepository;
            this.userToUserMapper = userToUserMapper;
            this.saveUserToUserMapper = saveUserToUserMapper;
        }

        public async Task<IActionResult> ExecuteAsync(int userId, SaveUser saveUser, CancellationToken cancellationToken)
        {
            var user = await this.userRepository.GetAsync(userId, cancellationToken).ConfigureAwait(false);
            if (user is null)
            {
                return new NotFoundResult();
            }

            this.saveUserToUserMapper.Map(saveUser, user);
            user = await this.userRepository.UpdateAsync(user, cancellationToken).ConfigureAwait(false);
            var userViewModel = this.userToUserMapper.Map(user);

            return new OkObjectResult(userViewModel);
        }
    }
}

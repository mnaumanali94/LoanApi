namespace LoanApi.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using LoanApi.Constants;
    using LoanApi.Repositories;
    using LoanApi.ViewModels;
    using Boxed.Mapping;
    using Microsoft.AspNetCore.Mvc;

    public class PostUserCommand : IPostUserCommand
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper<Models.User, User> userToUserMapper;
        private readonly IMapper<SaveUser, Models.User> saveUserToUserMapper;

        public PostUserCommand(
            IUserRepository userRepository,
            IMapper<Models.User, User> userToUserMapper,
            IMapper<SaveUser, Models.User> saveUserToUserMapper)
        {
            this.userRepository = userRepository;
            this.userToUserMapper = userToUserMapper;
            this.saveUserToUserMapper = saveUserToUserMapper;
        }

        public async Task<IActionResult> ExecuteAsync(SaveUser saveUser, CancellationToken cancellationToken)
        {
            var user = this.saveUserToUserMapper.Map(saveUser);
            user = await this.userRepository.AddAsync(user, cancellationToken).ConfigureAwait(false);
            var userViewModel = this.userToUserMapper.Map(user);

            return new CreatedAtRouteResult(
                UsersControllerRoute.GetUser,
                new { userId = userViewModel.UserId },
                userViewModel);
        }
    }
}

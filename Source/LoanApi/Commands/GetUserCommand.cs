namespace LoanApi.Commands
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using LoanApi.Repositories;
    using LoanApi.ViewModels;
    using Boxed.Mapping;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.Net.Http.Headers;

    public class GetUserCommand : IGetUserCommand
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IUserRepository userRepository;
        private readonly IMapper<Models.User, User> userMapper;

        public GetUserCommand(
            IActionContextAccessor actionContextAccessor,
            IUserRepository userRepository,
            IMapper<Models.User, User> userMapper)
        {
            this.actionContextAccessor = actionContextAccessor;
            this.userRepository = userRepository;
            this.userMapper = userMapper;
        }

        public async Task<IActionResult> ExecuteAsync(int userId, CancellationToken cancellationToken)
        {
            var user = await this.userRepository.GetAsync(userId, cancellationToken).ConfigureAwait(false);
            if (user is null)
            {
                return new NotFoundResult();
            }

            var httpContext = this.actionContextAccessor.ActionContext.HttpContext;

            var userViewModel = this.userMapper.Map(user);

            return new OkObjectResult(userViewModel);
        }
    }
}

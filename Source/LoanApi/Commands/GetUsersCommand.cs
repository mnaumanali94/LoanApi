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

    public class GetUsersCommand : IGetUsersCommand
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IUserRepository userRepository;
        private readonly IMapper<Models.User, User> userMapper;

        public GetUsersCommand(
            IActionContextAccessor actionContextAccessor,
            IUserRepository userRepository,
            IMapper<Models.User, User> userMapper)
        {
            this.actionContextAccessor = actionContextAccessor;
            this.userRepository = userRepository;
            this.userMapper = userMapper;
        }

        public async Task<IActionResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            var users = await this.userRepository.GetUsersAsync(cancellationToken).ConfigureAwait(false);
            if (users is null)
            {
                return new NotFoundResult();
            }

            var httpContext = this.actionContextAccessor.ActionContext.HttpContext;

            var userViewModels = this.userMapper.MapList(users);

            return new OkObjectResult(userViewModels);
        }
    }
}

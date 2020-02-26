namespace LoanApi.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using LoanApi.Repositories;
    using Microsoft.AspNetCore.Mvc;

    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IUserRepository userRepository;

        public DeleteUserCommand(IUserRepository userRepository) =>
            this.userRepository = userRepository;

        public async Task<IActionResult> ExecuteAsync(int userId, CancellationToken cancellationToken)
        {
            var user = await this.userRepository.GetAsync(userId, cancellationToken).ConfigureAwait(false);
            if (user is null)
            {
                return new NotFoundResult();
            }

            await this.userRepository.DeleteAsync(user, cancellationToken).ConfigureAwait(false);

            return new NoContentResult();
        }
    }
}

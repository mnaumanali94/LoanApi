namespace LoanApi.Commands
{
    using Boxed.AspNetCore;

    public interface IGetUserCommand : IAsyncCommand<int>
    {
    }
}

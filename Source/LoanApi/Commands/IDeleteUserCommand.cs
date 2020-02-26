namespace LoanApi.Commands
{
    using Boxed.AspNetCore;

    public interface IDeleteUserCommand : IAsyncCommand<int>
    {
    }
}

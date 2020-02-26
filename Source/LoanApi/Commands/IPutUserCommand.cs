namespace LoanApi.Commands
{
    using LoanApi.ViewModels;
    using Boxed.AspNetCore;

    public interface IPutUserCommand : IAsyncCommand<int, SaveUser>
    {
    }
}

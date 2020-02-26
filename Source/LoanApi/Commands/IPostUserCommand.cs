namespace LoanApi.Commands
{
    using LoanApi.ViewModels;
    using Boxed.AspNetCore;

    public interface IPostUserCommand : IAsyncCommand<SaveUser>
    {
    }
}

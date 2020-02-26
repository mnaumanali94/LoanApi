namespace LoanApi
{
    using LoanApi.Commands;
    using LoanApi.Mappers;
    using LoanApi.Repositories;
    using LoanApi.ViewModels;
    using Boxed.Mapping;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods add project services.
    /// </summary>
    /// <remarks>
    /// AddSingleton - Only one instance is ever created and returned.
    /// AddScoped - A new instance is created and returned for each request/response cycle.
    /// AddTransient - A new instance is created and returned each time.
    /// </remarks>
    public static class ProjectServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectCommands(this IServiceCollection services) =>
            services
                .AddSingleton<IDeleteUserCommand, DeleteUserCommand>()
                .AddSingleton<IGetUserCommand, GetUserCommand>()
                .AddSingleton<IPostUserCommand, PostUserCommand>()
                .AddSingleton<IPutUserCommand, PutUserCommand>()
                .AddSingleton<IGetUsersCommand, GetUsersCommand>();

        public static IServiceCollection AddProjectMappers(this IServiceCollection services) =>
            services
                .AddSingleton<IMapper<Models.User, User>, UserToUserMapper>()
                .AddSingleton<IMapper<Models.User, SaveUser>, UserToSaveUserMapper>()
                .AddSingleton<IMapper<SaveUser, Models.User>, UserToSaveUserMapper>();

        public static IServiceCollection AddProjectRepositories(this IServiceCollection services) =>
            services
                .AddSingleton<IUserRepository, UserRepository>();
    }
}

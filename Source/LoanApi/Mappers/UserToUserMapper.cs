namespace LoanApi.Mappers
{
    using System;
    using LoanApi.Constants;
    using LoanApi.ViewModels;
    using Boxed.Mapping;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;

    public class UserToUserMapper : IMapper<Models.User, User>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly LinkGenerator linkGenerator;

        public UserToUserMapper(
            IHttpContextAccessor httpContextAccessor,
            LinkGenerator linkGenerator)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.linkGenerator = linkGenerator;
        }

        public void Map(Models.User source, User destination)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination is null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            destination.UserId = source.UserId;
            destination.IncorporationDate = source.IncorporationDate;
            destination.LoanPurpose = source.LoanPurpose;
            destination.Industry = source.Industry;
            destination.RequestedAmount = source.RequestedAmount;
            destination.Revenue = source.Revenue;
            destination.Url = new Uri(this.linkGenerator.GetUriByRouteValues(
                this.httpContextAccessor.HttpContext,
                UsersControllerRoute.GetUser,
                new { source.UserId }));
        }
    }
}

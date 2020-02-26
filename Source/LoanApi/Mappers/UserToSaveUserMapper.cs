namespace LoanApi.Mappers
{
    using System;
    using LoanApi.ViewModels;
    using Boxed.Mapping;

    public class UserToSaveUserMapper : IMapper<Models.User, SaveUser>, IMapper<SaveUser, Models.User>
    {
        public void Map(Models.User source, SaveUser destination)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination is null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            destination.IncorporationDate = source.IncorporationDate;
            destination.LoanPurpose = source.LoanPurpose;
            destination.Industry = source.Industry;
            destination.RequestedAmount = source.RequestedAmount;
            destination.Revenue = source.Revenue;
        }

        public void Map(SaveUser source, Models.User destination)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination is null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            destination.IncorporationDate = source.IncorporationDate;
            destination.LoanPurpose = source.LoanPurpose;
            destination.Industry = source.Industry;
            destination.RequestedAmount = source.RequestedAmount;
            destination.Revenue = source.Revenue;
        }
    }
}

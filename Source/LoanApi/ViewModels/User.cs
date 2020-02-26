namespace LoanApi.ViewModels
{
    using System;

    /// <summary>
    /// A make and model of car.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id of the user.
        /// </summary>
        /// <example>/users/1</example>
        public int UserId { get; set; }

        /// <summary>
        /// Incorporation date of the organisation.
        /// </summary>
        public DateTime IncorporationDate { get; set; }

        /// <summary>
        /// Purpose of the loan.
        /// </summary>
        public string LoanPurpose { get; set; }

        /// <summary>
        /// Industry of the organisation.
        /// </summary>
        public string Industry { get; set; }

        /// <summary>
        /// Revenue of the organisation.
        /// </summary>
        public int Revenue { get; set; }

        /// <summary>
        /// Amount requested by the user.
        /// </summary>
        public int RequestedAmount { get; set; }

        /// <summary>
        /// Gets or sets the URL used to retrieve the resource conforming to REST'ful JSON http://restfuljson.org/.
        /// </summary>
        /// <example>/users/1</example>
        public Uri Url { get; set; }
    }
}

namespace LoanApi.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// A make and model of car.
    /// </summary>
    public class SaveUser
    {
        /// <summary>
        /// Incorporation date of the organisation.
        /// </summary>
        [Required]
        public DateTime IncorporationDate { get; set; }

        /// <summary>
        /// Purpose of the loan.
        /// </summary>
        [Required]
        public string LoanPurpose { get; set; }

        /// <summary>
        /// Industry of the organisation.
        /// </summary>
        [Required]
        public string Industry { get; set; }

        /// <summary>
        /// Revenue of the organisation.
        /// </summary>
        [Required]
        public int Revenue { get; set; }

        /// <summary>
        /// Amount requested by the user.
        /// </summary>
        [Required]
        public int RequestedAmount { get; set; }
    }
}

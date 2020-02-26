namespace LoanApi.Models
{
    using System;

    public class User
    {
        public int UserId { get; set; }

        public DateTime IncorporationDate { get; set; }

        public string LoanPurpose { get; set; }

        public string Industry { get; set; }

        public int Revenue { get; set; }

        public int RequestedAmount { get; set; }
    }
}
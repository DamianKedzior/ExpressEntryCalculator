using System;

namespace ExpressEntryCalculator.Api.Models
{
    public class ExpressEntryStats
    {
        public DateTime RoundDate { get; set; }
        public int LowestScore { get; set; }
        public int InvitationsIssued { get; set; }
    }
}

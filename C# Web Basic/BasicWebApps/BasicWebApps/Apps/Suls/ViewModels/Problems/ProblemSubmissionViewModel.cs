using System;

namespace Suls.ViewModels.Problems
{
    public class ProblemSubmissionViewModel
    {
        public string Username { get; set; }

        public string SubmissionId { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public int Percentage => (int)Math.Round(this.AchievedResult * 100.0 / this.MaxPoints);
    }
}

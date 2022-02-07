using System.Collections.Generic;

namespace Suls.ViewModels.Problems
{
    public class ProblemViewModel
    {
        public string Name { get; set; }

        public IEnumerable<ProblemSubmissionViewModel> Submissions { get; set; }
    }
}

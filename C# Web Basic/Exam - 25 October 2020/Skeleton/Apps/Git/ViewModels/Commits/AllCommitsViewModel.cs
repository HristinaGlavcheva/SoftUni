using System;

namespace Git.ViewModels.Commits
{
    public class AllCommitsViewModel
    {
        public string Description { get; set; }

        public string Repository { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

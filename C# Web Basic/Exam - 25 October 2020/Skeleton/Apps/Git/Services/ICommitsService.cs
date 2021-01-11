using Git.ViewModels.Commits;
using System.Collections;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        void Create(string id, string repositoryId, string userId, string description);

        IEnumerable<AllCommitsViewModel> GetAllCommits(string userId);
    }
}

using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        public IEnumerable<RepositoryViewModel> GetAll();

        public void CreateRepository(CreateRepositoryInputModel input, string userId);

        public string GetNameById(string id);
    }
}

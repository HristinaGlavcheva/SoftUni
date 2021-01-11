using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        public void CreateRepository(RepositoryViewModel repositoryViewModel, string ownerId);

        public IEnumerable<AllRepositoriesViewModel> GetAll();
    }
}

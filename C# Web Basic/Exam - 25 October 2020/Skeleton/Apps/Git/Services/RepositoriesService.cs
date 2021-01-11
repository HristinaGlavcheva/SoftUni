using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateRepository(CreateRepositoryInputModel input, string userId)
        {
            var repository = new Repository
            {
                Name = input.Name,
                IsPublic = input.Type == "Public",
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,
            };

            this.db.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            var repositories = this.db.Repositories.Where(x => x.IsPublic == false).Select(x => new RepositoryViewModel
            {
                Name = x.Name,
                Owner = x.Owner.Username,
                Created = x.CreatedOn,
                Commits = x.Commits.Count,
            }).ToList();

            return repositories;
        }

        public string GetNameById(string id)
        {
            //return this.db.Repositories.FirstOrDefault(x => x.Id == id).Name; ?? Null reference exception

            return this.db.Repositories.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
        }
    }
}

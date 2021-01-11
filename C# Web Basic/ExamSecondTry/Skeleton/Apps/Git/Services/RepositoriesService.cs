using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        
        public void CreateRepository(RepositoryViewModel repositoryViewModel, string userId)
        {
            var owner = this.db.Users.FirstOrDefault(x => x.Id == userId);
            var ownerName = owner.Username;

            var repository = new Repository
            {
                Name = repositoryViewModel.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = repositoryViewModel.RepositoryType == "Public",
                OwnerId = userId,
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        //public void CreateRepository(CreateRepositoryInputModel input, string userId)
        //{
        //    var repository = new Repository
        //    {
        //        Name = input.Name,
        //        IsPublic = input.Type == "Public",
        //        CreatedOn = DateTime.UtcNow,
        //        OwnerId = userId,
        //    };

        //    this.db.Add(repository);
        //    this.db.SaveChanges();
        //}

        public IEnumerable<AllRepositoriesViewModel> GetAll()
        {
            var repos = this.db.Repositories.Where(x => x.IsPublic).Select(x => new AllRepositoriesViewModel
            {
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = x.CreatedOn,
                CommitsCount = x.Commits.Count,
            }).ToList();

            return repos;
        }
    }
}

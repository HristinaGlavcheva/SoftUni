using Git.Data;
using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        
        public void Create(string id, string repositoryId, string userId, string description)
        {
            var repo = this.db.Repositories.Where(x => x.Commits.Any(y => y.Id == id)).FirstOrDefault();

            var commit = new Commit
            {
                RepositoryId = repositoryId,
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        //public string CreateCommit(string description, string id, string userId, string repoId)
        //{
        //    var repo = this.db.Repositories.Where(x => x.Commits.Any(y => y.Id == id)).FirstOrDefault();

        //    var creator = this.db.Users.Where(x => x.Id == userId).FirstOrDefault();

        //    var commit = new Commit
        //    {
        //        CreatedOn = DateTime.UtcNow,
        //        Description = description,
        //        CreatorId = creator.Id,
        //        RepositoryId = repoId,
        //    };

        //    this.db.Commits.Add(commit);
        //    this.db.SaveChanges();
        //    return commit.Id;
        //}

        public IEnumerable<AllCommitsViewModel> GetAllCommits(string userId)
        {
            var commits = this.db.Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new AllCommitsViewModel
                {
                    Description = x.Description,
                    CreatedOn = x.CreatedOn,
                    Repository = x.Repository.Name
                }).ToList();
         
            return commits;
        }
    }
}

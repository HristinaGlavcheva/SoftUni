using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.commitsService.GetAllCommits(this.GetUserId());

            return this.View(viewModel);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CommitViewModel
            {
                Name = this.repositoriesService.GetNameById(id),
                Id = id,
            };
            
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string id, string repositoryId, string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(description) || description.Length < 5)
            {
                return this.Error("Description should be minimum 5 characters long.");
            }

            this.commitsService.Create(id, repositoryId, this.GetUserId(), description);

            return this.Redirect("/Repositories/All");
        }

        //[HttpPost]
        //public HttpResponse Create(string description, string id, string repoId)
        //{
        //    if (!this.IsUserSignedIn())
        //    {
        //        return this.Redirect("/Users/Login");
        //    }

        //    if (string.IsNullOrWhiteSpace(description) || description.Length < 5)
        //    {
        //        return this.Error("Description should be at least 5 characters long.");
        //    }

        //    var userId = this.GetUserId();
        //    this.commitsService.CreateCommit(description, id, userId, repoId);
        //    return this.Redirect("/Repositories/All");
        //}
    }
}

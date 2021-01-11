using Git.Services;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }
        
        public HttpResponse Create()
        {
            //if (!this.IsUserSignedIn())
            //{
            //    return this.Redirect("/Users/Login");
            //}

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(RepositoryViewModel viewModel)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrEmpty(viewModel.Name) || viewModel.Name.Length < 3 || viewModel.Name.Length > 10)
            {
                return this.Error("Repository name should be between 3 and 10 characters.");
            }

            var userId = this.GetUserId();
            this.repositoriesService.CreateRepository(viewModel, userId);
            return this.Redirect("/Repositories/All");
        }

        //public HttpResponse Create(CreateRepositoryInputModel input)
        //{
        //    if (!IsUserSignedIn())
        //    {
        //        return this.Redirect("/");
        //    }

        //    if (string.IsNullOrEmpty(input.Name) || input.Name.Length < 3 || input.Name.Length > 10)
        //    {
        //        return this.Error("Repository name should be between 3 and 10 characters long.");
        //    }

        //    var userId = this.GetUserId();
        //    this.repositoriesService.CreateRepository(input, userId);
        //    return this.Redirect("/");
        //}

        public HttpResponse All()
        {
            var model = this.repositoriesService.GetAll();

            return this.View(model);
        }
    }
}

using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MySulsExam.Services;
using MySulsExam.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Net.Http.Headers;

namespace MySulsExam.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }
        
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CreateSubmissionViewModel
            {
                Name = this.problemsService.GetNameById(id),
                ProblemId = id, 
            };
            
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string code, string problemId)
        {
            if(string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characters.");
            }

            var userId = this.GetUserId();
            this.submissionsService.Create(problemId, userId, code);
            
            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
